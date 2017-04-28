using System;

namespace TagLookup
{
    class ExposedWebsitesConfiguration : XmlConfiguration, IDisposable
    {
        #region Fields
        private static ExposedWebsitesConfiguration exposedWebsitesConfigurationInstance = new ExposedWebsitesConfiguration();
        private ExposedWebsites exposedWebsites;
        #endregion

        #region Properties
        /// <summary>
        /// Get a reference to the singleton
        /// </summary>
        public static ExposedWebsitesConfiguration ExposedWebsitesConfigurationInstance
        {
            get
            {
                return exposedWebsitesConfigurationInstance;
            }
        }

        /// <summary>
        /// Get a reference to self contained object 
        /// </summary>
        public ExposedWebsites ExposedWebsites
        {
            get
            {
                return exposedWebsitesConfigurationInstance.exposedWebsites;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Write to disk before removing all references
        /// </summary>
        public void Dispose()
        {
            Dispose( exposedWebsites, typeof( ExposedWebsites ) );
            exposedWebsitesConfigurationInstance = null;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Initialization called only once by the exposedTagsConfigurationInstance
        /// </summary>
        private ExposedWebsitesConfiguration() : 
            base( "ExposedWebsitesFilePath", "ExposedWebsitesFileName", "ExposedWebsites.xml", out Program.obj, typeof( ExposedWebsites )  )
        {
            exposedWebsites = Program.obj as ExposedWebsites;
            if( exposedWebsites == null )
            {
                exposedWebsites = new ExposedWebsites();
            }
        }
        #endregion
    }
}
