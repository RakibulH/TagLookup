using System;
using System.Configuration;
using System.IO;
using System.Security.Permissions;
using System.Xml;
using System.Xml.Serialization;

namespace TagLookup
{
    /// <summary>
    /// Encapsulates common logic for xml configuration file usage
    /// </summary>
    public abstract class XmlConfiguration
    {
        #region Fields
        protected string configFileName;
        protected string configFileDir;
        #endregion

        #region Protected Methods
        /// <summary>
        /// Write to disk before removing all references
        /// </summary>
        protected void Dispose( object containedObject, Type objectType )
        {
            if( containedObject != null )
            {
                try
                {
                    if( !Directory.Exists( configFileDir ) )
                    {
                        Directory.CreateDirectory( configFileDir );
                    }

                    var path = Path.Combine( configFileDir, configFileName );
                    var serializer = new XmlSerializer( objectType );

                    // need to overwrite
                    if( File.Exists( path ) )
                    {
                        File.SetAttributes( path, FileAttributes.Normal );
                        FileIOPermission filePermission =
                                 new FileIOPermission( FileIOPermissionAccess.AllAccess, path );

                        var serialized = new XmlSerializer( objectType );
                        using( var fs = new FileStream( path, FileMode.Create ) )
                        {
                            using( XmlWriter writer = XmlWriter.Create( fs ) )
                            {
                                serialized.Serialize( writer, containedObject );
                            }
                        }
                    }
                    else
                    {
                        using( var writer = XmlWriter.Create( path ) )
                        {
                            serializer.Serialize( writer, containedObject );
                        }
                    }
                }
                catch
                {
                    // setting aren't saved
                }
            }
        }

        /// <summary>
        /// Initialization called by the base class. Finds the file, and creates the specified object
        /// </summary>
        /// <param name="appconfigDir">Will be looked up in the app config</param>
        /// <param name="appconfigDirName">Will be looked up in the app config</param>
        /// <param name="configFileName">The name of the actual xml file</param>
        /// <param name="readObject">The object to generate via deserialization</param>
        /// <param name="objectType">The type of the object</param>
        protected XmlConfiguration( string appconfigDir, string appconfigDirName, string configFileName,
                                    out object readObject, Type objectType )
        {
            string dir = null;
            string name = null;
            readObject = null;

            // Dir and Name
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                dir = appSettings[ appconfigDir ];
                name = appSettings[ appconfigDirName ];
            }
            catch( ConfigurationErrorsException )
            {
                // Not strictly necessary
            }

            // Two passes to try and create the object from either a different directory
            // or the default directory (to achieve persistence from any location)
            if( !createConfigurationFile( dir, name, out readObject, objectType ) )
            {
                configFileDir = Directory.GetCurrentDirectory();
                createConfigurationFile( configFileDir, configFileName, out readObject, objectType );
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Attempt to create the object via deserialization
        /// </summary>
        /// <param name="dir">Directory of file</param>
        /// <param name="name">Name of file</param>
        /// <param name="readObject">Will contain a reference to deserialized object on success, null on failure</param>
        /// <param name="objectType">The type the deserilizer will try to use</param>
        /// <returns>True on success, False on failure</returns>
        private bool createConfigurationFile( string dir, string name, out object readObject, Type objectType )
        {
            readObject = null;
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

                var serializer = new XmlSerializer( objectType );
                using( var reader = XmlReader.Create( path ) )
                {
                    readObject = serializer.Deserialize( reader );
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
