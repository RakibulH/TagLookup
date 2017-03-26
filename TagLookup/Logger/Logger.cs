using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace TagLookup
{
    /// <summary>
    /// Singleton responsible for doing all logging and book keeping
    /// Written under the assumption that no more than one instance of this application at one time
    /// </summary>
    public class Logger : IDisposable
    {
        #region Fields
        private static Logger loggerInstance = new Logger();
        private StreamWriter streamWriter;
        private TextBox logTextBox;
        #endregion

        #region Accessors
        /// <summary>
        /// Get a reference to the singleton 
        /// </summary>
        public static Logger LoggerInstance
        {
            get
            {
                return loggerInstance;
            }
        }

        /// <summary>
        /// Set a logTextBox to also log to
        /// </summary>
        public TextBox LogTextBox
        {
            set
            {
                logTextBox = value;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Opens stream and appends message, context, and date onto a new line
        /// </summary>
        /// <param name="context">Method Name</param>
        /// <param name="message">Message</param>
        public void Log( string message )
        {
            if( streamWriter != null )
            {
                streamWriter.WriteLine( "{0} {1,-10}\n", DateTime.Now.ToString(), message );
            }
            if( logTextBox != null )
            {
                logTextBox.AppendText( message );
            }
        }

        /// <summary>
        /// Writes to disk, and releases stream writer
        /// </summary>
        public void Dispose()
        {
            if( streamWriter != null )
            {
                streamWriter.Close();
                streamWriter.Dispose();
            }
            logTextBox = null;
            loggerInstance = null;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Initialization called only once by the loggerInstance
        /// </summary>
        private Logger()
        {
            string logFileDir = null;
            string logFileName = null;

            // Dir and Name
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                logFileDir = appSettings["DefaultLogFilePath"];
                logFileName = appSettings["DefaultLogFileName"];
            }
            catch( ConfigurationErrorsException )
            {
                // Not strictly necessary
            }

            // Two passes to try and create a stream writer
            if( !createStreamWriter( logFileDir, logFileName ) )
            {
                if( !createStreamWriter( Directory.GetCurrentDirectory(), "tagFetcherLog.txt" ) )
                {
                    streamWriter = null;
                }
            }
        }

        /// <summary>
        /// Attempts to create private stream writer object
        /// </summary>
        /// <param name="logFileDir">Log File Directory</param>
        /// <param name="logFileName">Log File Name</param>
        /// <returns>True on success, False on failure</returns>
        private bool createStreamWriter( string logFileDir, string logFileName )
        {
            if( logFileDir == null || logFileName == null )
            {
                return false;
            }

            if( !Directory.Exists( logFileDir ) )
            {
                Directory.CreateDirectory( logFileDir );
            }
            var logFilePath = Path.Combine( logFileDir, logFileName );

            // Check if writable
            try
            {
                streamWriter = File.CreateText( logFilePath );
                streamWriter.WriteLine( "{0} {1,-10}",
                    DateTime.Now.ToString(),
                    "Successfully created logger object" );
            }
            catch( Exception )
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}