using System;
using System.Configuration;
using System.IO;
using System.Security.Permissions;
using System.Xml;
using System.Xml.Serialization;

namespace TagLookup
{
    public class ExposedTagsConfiguration : IDisposable
    {
        #region Fields
        private static ExposedTagsConfiguration exposedTagsConfigurationInstance = new ExposedTagsConfiguration();
        private ExposedTags exposedTags;
        private string configFileName;
        private string configFileDir;
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
            if( exposedTags != null )
            {
                try
                {
                    if( !Directory.Exists( configFileDir ) )
                    {
                        Directory.CreateDirectory( configFileDir );
                    }

                    var path = Path.Combine( configFileDir, configFileName );
                    var serializer = new XmlSerializer( exposedTags.GetType() );
                    
                    // need to overwrite
                    if( File.Exists( path ) )
                    {
                        File.SetAttributes( path, FileAttributes.Normal );
                        FileIOPermission filePermission =
                                 new FileIOPermission( FileIOPermissionAccess.AllAccess, path );

                        var serialized = new XmlSerializer( exposedTags.GetType() );
                        using( var fs = new FileStream( path, FileMode.Create ) )
                        {
                            using( XmlWriter writer = XmlWriter.Create( fs ) )
                            {
                                serialized.Serialize( writer, exposedTags );
                            }
                        }
                    }
                    else
                    {
                        using( var writer = XmlWriter.Create( path ) )
                        {
                            serializer.Serialize( writer, exposedTags );
                        }
                    }
                }
                catch
                {
                    // setting aren't saved
                }
            }

            exposedTagsConfigurationInstance = null;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Initialization called only once by the exposedTagsConfigurationInstance
        /// </summary>
        private ExposedTagsConfiguration()
        {
            string dir = null;
            string name = null;

            // Dir and Name
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                dir = appSettings[ "ExposedTagsFilePath" ];
                name = appSettings[ "ExposedTagsFileName" ];
            }
            catch( ConfigurationErrorsException )
            {
                // Not strictly necessary
            }

            // Two passes to try and create the Exposed tags from either a different directory
            // or the default directory (to achieve persistence from any location)
            if( !createConfigurationFile( dir, name ) )
            {
                configFileDir = Directory.GetCurrentDirectory();
                configFileName = "ExposedTags.xml";

                if( !createConfigurationFile( configFileDir, configFileName ) ) 
                {
                    exposedTags = new ExposedTags();
                    exposedTags.CreateDefault();
                }
            }
        }

        /// <summary>
        /// Attempt to create the ExposedTags object via deserialization
        /// </summary>
        /// <param name="dir">Directory of file</param>
        /// <param name="name">Name of file</param>
        /// <returns>True on success, False on failure</returns>
        private bool createConfigurationFile( string dir, string name )
        {
            if( dir == null || name == null )
            {
                return false;
            }

            try
            {
                if( !Directory.Exists( dir ) )
                {
                    Directory.CreateDirectory( dir );
                }
                var path = Path.Combine( dir, name );

                var serializer = new XmlSerializer( typeof( ExposedTags ) );
                using( var reader = XmlReader.Create( path ) )
                {
                    exposedTags = ( ExposedTags )serializer.Deserialize( reader );
                }
            }
            catch( Exception )
            {
                return false;
            }

            configFileDir = dir;
            configFileName = name;
            return true;
        }
        #endregion
    }
}