using System;

namespace TagLookup
{
    public class ExposedTagsConfiguration : XmlConfiguration , IDisposable
    {
        #region Fields
        private static ExposedTagsConfiguration exposedTagsConfigurationInstance = new ExposedTagsConfiguration();
        private ExposedTags exposedTags;
        #endregion

        #region Properties
        /// <summary>
        /// Get a reference to the singleton
        /// </summary>
        public static ExposedTagsConfiguration ExposedTagsConfigurationInstance
        {
            get
            {
                return exposedTagsConfigurationInstance;
            }
        }

        /// <summary>
        /// Get a reference to self contained object 
        /// </summary>
        public ExposedTags ExposedTags
        {
            get
            {
                return exposedTagsConfigurationInstance.exposedTags;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Write to disk before removing all references
        /// </summary>
        public void Dispose()
        {
            Dispose( exposedTags, typeof( ExposedTags ) );
            exposedTagsConfigurationInstance = null;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Initialization called only once by the exposedTagsConfigurationInstance
        /// </summary>
        private ExposedTagsConfiguration( ) : 
            base( "ExposedTagsFilePath", "ExposedTagsFileName", "ExposedTags.xml", out Program.obj, typeof( ExposedTags )  )
        {
            exposedTags = Program.obj as ExposedTags;
            if( exposedTags == null )
            {
                exposedTags = new ExposedTags();
                exposedTags.CreateDefault();
            }
        }
        #endregion
    }
}