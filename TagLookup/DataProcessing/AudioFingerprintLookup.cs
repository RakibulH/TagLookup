using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Linq;
using NAudio.Wave;

namespace TagLookup
{
    public class AudioFingerprintLookup
    {
        #region Fields
        private Logger log;                         // reference to logger singleton
        private Process fingerprintApplication;     // fingerprint application initialized from Initialize method
        private StringBuilder applicationArguments; // spaces in file name require quotes, so use this
        private HttpClient httpClient;              // used to interact with Acoustid web api
        private StringBuilder acoustidPayload;      // used to create payload
        
        // hard coded these for testing, will probably move
        private static string acoustid = "http://api.acoustid.org/v2/lookup?{0}meta=recordingids"; // +recordings+releases+releaseids+releasegroups+releasegroupids+tracks+compress+usermeta+sources
        private static string apiKey = "W4Zx4nV3xp";
        private static string musicbrainz = "http://musicbrainz.org/ws/2/recording/{0}?inc=artist-credits+releases+discids&fmt=json";
        private const string userAgent = @"Mozilla / 5.0( Windows NT 6.3; WOW64; rv: 54.0) Gecko / 20100101 Firefox / 54.0"; // Musicbrainz api needs this
        #endregion

        #region Constructors
        public AudioFingerprintLookup()
        {
            log = Logger.LoggerInstance;
            Initialize();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Attempt to invoke the application, create a Json object
        /// </summary>
        /// <param name="item">Mp3 file to do a lookup on</param>
        /// <exception>Throws an exception if unable to create the Json object, or http request did not succeed</exception>
        public void Lookup( Mp3File item )
        {
            var fingerprint = GetFingerprint( item.AbsolutePath );
            var fingerprintJson = JsonConvert.DeserializeObject< JObject >( fingerprint );
            fingerprintJson.Add( "client", apiKey );

            // Remote api does not like decimal values
            var duration = ( JProperty )fingerprintJson.Children().Where( 
                x => ( ( JProperty )x ).Name == "duration" ).FirstOrDefault();
            if( duration != null )
            {
                duration.Value = Math.Round( ( ( double )duration.Value ) );
            }

            var acoustidJson = LookupByFingerprint( fingerprintJson );
            var musicbrainzJson = LookupByAcoustid( acoustidJson );

            MapMusicBrainzResponseToMp3( item, musicbrainzJson );
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// Attempt to see if the audio fingerprint application as specified by the user is invokable
        /// </summary>
        private void Initialize()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                var dir = appSettings[ "AudioFingerprintApplicationPath" ];
                var name = appSettings[ "AudioFingerprintApplicationName" ];

                if( dir == null || name == null )
                {
                    log.Log( "WARNING: App.config missing application path and or name specifications.\n" );
                }

                if( !Directory.Exists( dir ) )
                {
                    log.Log( "WARNING: Audio fingerprint application path doesn't exist.\n" );
                }
                var applicationAbsolutePath = Path.Combine( dir, name );


                if( !File.Exists( applicationAbsolutePath ) )
                {
                    log.Log( "WARNING: Audio fingerprint application doesn't exist.\n" );
                }

                // Check if we can invoke the application
                try
                {
                    // Create process object with suppressed output
                    fingerprintApplication = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = applicationAbsolutePath,
                            RedirectStandardInput = true,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true,
                            UseShellExecute = false
                        }
                    };

                    fingerprintApplication.Start();
                    var output = fingerprintApplication.StandardOutput.ReadToEnd() + fingerprintApplication.StandardError.ReadToEnd();
                    fingerprintApplication.WaitForExit();
                    
                    // initalize all other objects needed
                    applicationArguments = new StringBuilder();
                    httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation( "User-Agent", userAgent );
                    acoustidPayload = new StringBuilder( string.Empty );
                }
                catch( Exception )
                {
                    log.Log( "WARNING: Cannot invoke audio fingerprint application.\n" );
                    if( fingerprintApplication != null )
                    {
                        fingerprintApplication.Dispose();
                    }
                }
            }
            catch( ConfigurationErrorsException )
            {
                log.Log( "WARNING: App.config missing." );
            }
        }

        /// <summary>
        /// Using a file name (absolute path), invoke the application
        /// </summary>
        /// <param name="fileName">Filename fed into application</param>
        /// <returns>Serialized Json on success, error string on failure</returns>
        private string GetFingerprint( string fileName )
        {
            // Get wave file, get fingerprint
            var wavFile = DecodeMp3( fileName );
            applicationArguments.Clear();
            applicationArguments.AppendFormat( "-json \"{0}\"", wavFile );
            fingerprintApplication.StartInfo.Arguments = applicationArguments.ToString();
            fingerprintApplication.Start();
            var output = fingerprintApplication.StandardOutput.ReadToEnd() + fingerprintApplication.StandardError.ReadToEnd();
            fingerprintApplication.WaitForExit();

            // Don't need wave file anymore
            File.Delete( wavFile );
            return output;
        }

        /// <summary>
        /// Acoustic doesn't understand data formats, so we need to decode the mp3 file into wav
        /// </summary>
        /// <param name="fileName">mp3 file absolute path input</param>
        /// <returns>string absolute path of temp file</returns>
        private string DecodeMp3( string fileName )
        {
            var tempFile = Path.GetTempPath() + Guid.NewGuid().ToString() + ".wav";
            while( File.Exists( tempFile ) )
            {
                tempFile = Path.GetTempPath() + Guid.NewGuid().ToString() + ".wav";
            }
            using( var reader = new Mp3FileReader( fileName ) )
            {
                using( var pcmStream = WaveFormatConversionStream.CreatePcmStream( reader ) )
                {
                    WaveFileWriter.CreateWaveFile( tempFile, pcmStream );
                }
            }
            return tempFile;
        }

        /// <summary>
        /// Using the input JObject, creates the payload, and sends an http request
        /// </summary>
        /// <param name="fingerprintDeserialized">Assumes this object is in a good state and is parsed into a string string dictonary</param>
        /// <returns>Resulting JSon object of the http request</returns>
        private JObject LookupByFingerprint( JObject fingerprintDeserialized )
        {
            acoustidPayload.Clear();
            var values = fingerprintDeserialized.ToObject< Dictionary< string, string > >();
            foreach( var value in values )
            {
                acoustidPayload.AppendFormat( "{0}={1}&", value.Key, value.Value );
            }

            var acoustidApiCall = httpClient.GetAsync( string.Format( acoustid, acoustidPayload.ToString() ) );
            acoustidApiCall.Wait();
            acoustidApiCall.Result.EnsureSuccessStatusCode();
            
            return JsonConvert.DeserializeObject<JObject>( acoustidApiCall.Result.Content.ReadAsStringAsync().Result );
        }

        /// <summary>
        /// Using the Acoustid api call response, attempt to lookup the musicbrainz database via an api call
        /// </summary>
        /// <param name="acoustidJson">The raw response from acoustid api call</param>
        /// <returns>Resulting JSon object of the http request</returns>
        private JObject LookupByAcoustid( JObject acoustidJson )
        {
            var results = acoustidJson[ "results" ] as dynamic;
            if( acoustidJson == null || acoustidJson[ "status" ]?.ToString() != "ok" || results == null || results.Count <= 0 )
                return null;

            var recordingId = results.First[ "recordings" ]?.First[ "id" ]?.ToString();
            if( recordingId == null )
                return null;

            var musicBrainzApiCall = httpClient.GetAsync( string.Format( musicbrainz, recordingId ) );
            musicBrainzApiCall.Wait();
            musicBrainzApiCall.Result.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<JObject>( musicBrainzApiCall.Result.Content.ReadAsStringAsync().Result );
        }

        /// <summary>
        /// Does a known mapping from the foreign JSON object to dirty tags
        /// </summary>
        /// <param name="item">The mp3file reference to add dirty tags to</param>
        /// <param name="musicbrainzJson">The raw musicbrainz api response</param>
        private void MapMusicBrainzResponseToMp3( Mp3File item, JObject musicbrainzJson )
        {
            var artistInfoJson = musicbrainzJson[ "artist-credit" ].FirstOrDefault();
            var albumInfoJson = musicbrainzJson[ "releases" ].FirstOrDefault();
            var discInfoJson = albumInfoJson[ "media" ].FirstOrDefault();

            item.AddDirtyTag( "Artists", artistInfoJson.Value<string>( "name" ), false );
            item.AddDirtyTag( "Title", musicbrainzJson.Value<string>( "title" ), false );
            item.AddDirtyTag( "Album", albumInfoJson.Value<string>( "title" ), false );
            item.AddDirtyTag( "Year", albumInfoJson.Value<string>( "date" ), false );
            item.AddDirtyTag( "Genres", "", false );
            item.AddDirtyTag( "Composers", artistInfoJson.Value<string>( "name" ), false );
            item.AddDirtyTag( "PERFORMER", artistInfoJson.Value<string>( "name" ), false );
            item.AddDirtyTag( "AlbumArtists", artistInfoJson.Value<string>( "name" ), false );
            item.AddDirtyTag( "Track", discInfoJson.Value<string>( "position" ), false );
            item.AddDirtyTag( "TrackCount", discInfoJson.Value<string>( "track-count" ), false );
            item.AddDirtyTag( "Disc", "", false );
            item.AddDirtyTag( "DiscCount", discInfoJson[ "discs" ].Count().ToString(), false );
            item.AddDirtyTag( "Comment", string.Empty, false );
        }
        #endregion
    }
}
