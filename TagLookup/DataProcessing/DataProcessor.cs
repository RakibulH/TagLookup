using System.Collections.Generic;
using System.IO;

namespace TagLookup
{
    /// <summary>
    /// This class will provide all of the tag processing capabilites of the application
    /// i.e. the automatic retrieval method: lookup via audio file fingerprint
    ///      the automatic retrieval method: lookup via http screen scraping
    ///      the semi-automatic retrieval method: user helps in the screen scraping
    ///      the manual method: user can specify what tags they explicitly want
    /// </summary>
    public class DataProcessor
    {
        #region Fields
        private Logger log;                                     // reference to logger singleton
        private AudioFingerprintLookup audioFingerprintLookup;  // exposes audio fingerprint lookup funcitonality 
        private HttpScreenScraping httpScreenScrapping;         // exposes http screen scraping functionality
        #endregion

        #region Constructors
        public DataProcessor()
        {
            log = Logger.LoggerInstance;
            try
            {
                audioFingerprintLookup = new AudioFingerprintLookup();
            }
            catch
            {
                log.Log( "WARNING: Continuing without audio fingerprint lookup capabilities.\n" );
            }
            httpScreenScrapping = new HttpScreenScraping();
        }
        #endregion

        /// <summary>
        /// Process a single item
        /// </summary>
        /// <param name="itemsToProcess"></param>
        /// <returns></returns>
        public bool TryProcess( Mp3File itemToProcess, List<Website> targetWebsites )
        {
            var success = false;
            log.Log( "Processing item " + Path.GetFileName( itemToProcess.AbsolutePath ) + "\n" );

            if( audioFingerprintLookup != null )
            {
                try
                {
                    log.Log( "Attempting audio fingerprint lookup.\n" );
                    audioFingerprintLookup.Lookup( itemToProcess );
                    log.Log( "Audio fingerprint lookup successful.\n" );
                    success = true;
                }
                catch
                {
                    log.Log( "Audio fingerprint lookup failed.\n" );
                }
            }

            if( targetWebsites != null && targetWebsites.Count > 0 )
            {
                try
                {
                    log.Log( "Attempting screen scraping.\n" );
                    foreach( var website in targetWebsites )
                        httpScreenScrapping.Process( itemToProcess, website );
                    log.Log( "Screen scraping successful.\n" );
                    success = true;
                }
                catch
                {
                    log.Log( "Screen scraping failed.\n" );
                }
            }

            var mp3FileDialogue = new Mp3FileDialogue( itemToProcess );
            mp3FileDialogue.Show();

            return success;
        }
    }
}