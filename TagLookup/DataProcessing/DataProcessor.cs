using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;

namespace TagLookup
{
    /// <summary>
    /// This class will provide all of the tag processing capabilites of the application
    /// i.e. the automatic retrieval method: lookup via audio file finger print
    ///      the automatic retrieval method: lookup via screen scraping
    ///      the semi-automatic retrieval method: user helps in the screen scraping
    ///      the manual method: user can specify what tags they explicitly want
    /// </summary>
    public class DataProcessor
    {
        #region Fields
        private Logger log;                                     // reference to logger singleton
        private AudioFingerprintLookup audioFingerprintLookup;  // wrapper 
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
        }
        #endregion

        internal void Process( BindingList<Mp3File> itemsToProcess )
        {
            foreach( var item in itemsToProcess )
            {
                if( audioFingerprintLookup != null )
                {
                    log.Log( "Processing item " + Path.GetFileName( item.AbsolutePath ) + " using Acoustid fingerprint lookup." );
                    audioFingerprintLookup.Lookup( item );
                }
            }
        }
    }
}