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
        private StringBuilder payload;              // used to create payload
        
        // hard coded these for testing, will probably move
        private static string acoustid = "http://api.acoustid.org/v2/";
        private static string apiKey = "W4Zx4nV3xp";
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
            var fingerprintLookupReturnInfo = GetFingerprint( item.AbsolutePath );
            var result = JsonConvert.DeserializeObject< JObject >( fingerprintLookupReturnInfo );
            result.Add( "client", apiKey );

            // Remote api does not like double values
            var duration = ( JProperty ) result.Children().Where( 
                x => ( ( JProperty )x ).Name == "duration" ).FirstOrDefault();
            if( duration != null )
            {
                duration.Value = Math.Round( ( ( double )duration.Value ) );
            }

            LookupByFingerprint( result );
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
                    httpClient.BaseAddress = new Uri( acoustid );
                    payload = new StringBuilder( string.Empty );
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
        /// <returns>Resulting string of the http request</returns>
        private string LookupByFingerprint( JObject fingerprintDeserialized )
        {
            payload.Clear();
            var values = fingerprintDeserialized.ToObject< Dictionary< string, string > >();
            foreach( var value in values )
            {
                payload.AppendFormat( "{0}={1}&", value.Key, value.Value );
            }
            var response = httpClient.GetAsync( "lookup?" + payload.ToString() + "meta=recordings+recordingids+releases+releaseids+releasegroups+releasegroupids+tracks+compress+usermeta+sources" ).Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }   
        #endregion
    }
}
