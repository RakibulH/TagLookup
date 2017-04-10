using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace TagLookup
{
    [XmlRoot( "Tags" )]
    public class ExposedTags
    {
        #region Constructors
        /// <summary>
        /// Necessary for serialization
        /// </summary>
        public ExposedTags()
        {
        }
        #endregion

        #region Properties
        [XmlElement( "Tag" )]
        public List<Tag> Tags;
        #endregion

        #region Internal Objects
        /// <summary>
        /// Exposes the config file
        /// </summary>
        [XmlType]
        public class Tag
        {
            #region Constructors
            /// <summary>
            /// Necessary for serialization
            /// </summary>
            public Tag()
            {
            }

            public Tag( string name, bool privateFrame = false )
            {
                Name = name;
                PrivateFrame = privateFrame;
            }
            #endregion

            #region Properties
            [XmlAttribute( "Name" )]
            public string Name;

            [XmlAttribute( "PrivateFrame" )]
            public bool PrivateFrame;
            #endregion
        }
        #endregion

        #region Methods
        /// <summary>
        /// Used to create a default xml if none exist
        /// </summary>
        public void CreateDefault()
        {
            if( Tags == null )
            {
                Tags = new List<Tag>();
            }
            else
            {
                Tags.Clear();
            }
            
            foreach( var propertyInfo in typeof( TagLib.Tag ).GetProperties() )
            {
                if( propertyInfo.CanRead && propertyInfo.CanWrite )
                {
                    Tags.Add( new Tag( propertyInfo.Name ) );
                }
            }
        }

        /// <summary>
        /// Check if added name is a private frame or if it's a supported tag
        /// </summary>
        /// <param name="name">Name of tag</param>
        /// <returns>true if private frame, false if supported tag</returns>
        public bool IsPrivateFrame( string name )
        {
            foreach( var propertyInfo in typeof( TagLib.Tag ).GetProperties() )
            {
                if( propertyInfo.CanRead && propertyInfo.CanWrite && string.Equals( propertyInfo.Name, name ) )
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}