using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagLib;
using TagLib.Id3v2;

namespace TagLookup
{
    /// <summary>
    /// Container class to represent a single mp3 file
    /// </summary>
    public class Mp3File : IDisposable
    {
        #region Fields
        private File mp3File;                                       // File handle of the mp3file
        private List<TagProcessing> tags;                           // Contains current dirty tags
        private List<TagProcessing> copy;                           // A non working copy for fast resets
        #endregion

        #region Constructors
        public Mp3File( string value )
        {
            try
            {
                mp3File = File.Create( value );
            }
            catch
            {
                throw new Exception( "Unable to create TagLib File from absolute path." );
            }

            InitializeDirtyTags();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Figure out what kind of frame it is, then try to read it
        /// </summary>
        /// <param name="name">Name of frame</param>
        /// <param name="privateOrUserFrame">How to look for the frame</param>
        /// <param name="value">Value to hold output</param>
        /// <returns>True on success, false on failure</returns>
        public bool TryReadValue( string name, bool privateOrUserFrame, out string value )
        {
            if( !privateOrUserFrame )
            {
                return TryReadPropertyValue( name, out value );
            }
            else
            {
                if( !TryReadUserFrame( name, out value ) )
                {
                    if( !TryReadPrivateFrame( name, out value ) )
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Figure out what which tags have changes, edit accordingly, and save
        /// </summary>
        public void Save()
        {
            foreach( var tag in tags.Where( x => !string.Equals( x.tagValueNew, x.tagValueOld ) ) )
            {
                TryWriteValue( tag.tagName, tag.tagValueNew );
            }
            mp3File.Save();
            // Becuase we're not disposing this object yet, reset state for further use
            InitializeDirtyTags();
        }

        /// <summary>
        /// Get rid of file handle
        /// </summary>
        public void Dispose()
        {
            mp3File.Dispose();
        }

        /// <summary>
        /// Initialize tags and copy using exposed tags
        /// </summary>
        public void InitializeDirtyTags()
        {
            if( tags == null )
                tags = new List<TagProcessing>();
            else
                tags.Clear();

            if( copy == null )
                copy = new List<TagProcessing>();

            foreach( var tag in ExposedTagsConfiguration.ExposedTagsConfigurationInstance.ExposedTags.Tags )
            {
                try
                {
                    if( string.IsNullOrEmpty( tag.Name ) )
                    {
                        continue;
                    }

                    string tagValue;
                    TryReadValue( tag.Name, tag.PrivateOrUserFrame, out tagValue );
                    tags.Add( new TagProcessing( tag.Name, tagValue, tagValue ) );
                }
                catch
                {
                    // omit    
                }
            }

            copy = tags.ToList();
        }

        /// <summary>
        /// Deep clone the copy to revert changes on dirty tags
        /// </summary>
        public void ResetDirtyTags()
        {
            tags.Clear();
            copy.ForEach( tag => tags.Add( new TagProcessing( tag.tagName, tag.tagValueOld, tag.tagValueOld ) ) );
        }

        /// <summary>
        /// Change a tag value without saving changes
        /// </summary>
        /// <param name="tagName">Name of tag</param>
        /// <param name="tagValue">Value of tag as a string</param>
        /// <param name="append">Control to specify if appending is desired</param>
        public void AddDirtyTag( string tagName, string tagValue, bool append = true )
        {
            var targetTag = tags.Where( tag => tag.tagName == tagName ).FirstOrDefault();
            if( targetTag == null )
            {
                tags.Add( new TagProcessing( tagName, string.Empty, tagValue ) );
            }
            else if( append )
            {
                targetTag.tagValueNew += targetTag.tagValueNew == string.Empty ? "" : ";";
                targetTag.tagValueNew += tagValue;
            }
            else
            {
                targetTag.tagValueNew = tagValue;
            }
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// Attempts to read a tag in the object
        /// </summary>
        private bool TryReadPropertyValue( string name, out string value )
        {
            var obj = Tags.GetType().GetProperty( name ).GetValue( Tags, null );

            if( obj == null )
            {
                value = string.Empty;
                return false;
            }

            string arrayParser = null;
            if( Tags.GetType().GetProperty( name ).PropertyType == typeof( string[] ) )
                arrayParser = stringArrayToString( obj );

            if( arrayParser != null )
            {
                value = arrayParser;
                return true;
            }
            else
            {
                value = obj.ToString();
                return true;
            }
        }

        /// <summary>
        /// Attempt to read a private frame
        /// </summary>
        private bool TryReadPrivateFrame( string name, out string value )
        {
            try
            {
                TagLib.Id3v2.Tag tag = ( TagLib.Id3v2.Tag )mp3File.GetTag( TagTypes.Id3v2 );
                var privateFrame = PrivateFrame.Get( tag, name, false );
                value = Encoding.Unicode.GetString( privateFrame.PrivateData.Data );
                return true;
            }
            catch
            {
                value = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Attempt to read a user frame
        /// </summary>
        private bool TryReadUserFrame( string name, out string value )
        {
            try
            {
                TagLib.Id3v2.Tag tag = ( TagLib.Id3v2.Tag )mp3File.GetTag( TagTypes.Id3v2 );
                var userFrame = UserTextInformationFrame.Get( tag, name, false );
                value = stringArrayToString( userFrame.Text );
                return true;
            }
            catch
            {
                value = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Figure out what kind of frame it is, then try to write to it
        /// </summary>
        /// <param name="name">Name of frame</param>
        /// <param name="privateOrUserFrame">How to look for the frame</param>
        /// <param name="value">Value to write</param>
        /// <returns>True on success, false on failure</returns>
        private bool TryWriteValue( string name, string value )
        {
            if( !ExposedTags.IsPrivateOrUserFrame( name ) )
            {
                return TryWritePropertyValue( name, value );
            }
            else
            {
                string garbage;
                if( TryReadUserFrame( name, out garbage ) )
                {
                    return TryWriteUserFrame( name, value );
                }
                else
                {
                    return TryWritePrivateFrame( name, value );
                }
            }
        }

        /// <summary>
        /// Find the object property and overwrite
        /// </summary>
        private bool TryWritePropertyValue( string name, string value )
        {
            foreach( var propertyInfo in typeof( TagLib.Tag ).GetProperties() )
            {
                if( propertyInfo.CanRead && propertyInfo.CanWrite && string.Equals( propertyInfo.Name, name ) )
                {
                    if( propertyInfo.PropertyType == typeof( string[] ) )
                    {
                        Tags.GetType().GetProperty( name ).
                            SetValue( Tags, stringToStringArray( value ) );
                    }
                    else if( propertyInfo.PropertyType == typeof( uint ) )
                    {
                        uint temp;
                        if( uint.TryParse( value ?? "0", out temp ) )
                        {
                            Tags.GetType().GetProperty( name ).
                                SetValue( Tags, temp );
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        Tags.GetType().GetProperty( name ).
                            SetValue( Tags, value );
                    }

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Attempt to write a private frame
        /// </summary>
        private bool TryWritePrivateFrame( string name, string value )
        {
            try
            {
                TagLib.Id3v2.Tag tag = ( TagLib.Id3v2.Tag )mp3File.GetTag( TagTypes.Id3v2, true );
                var privateFrame = PrivateFrame.Get( tag, name, true );
                privateFrame.PrivateData = Encoding.Unicode.GetBytes( value ?? string.Empty );
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Attempt to write a private frame
        /// </summary>
        private bool TryWriteUserFrame( string name, string value )
        {
            try
            {
                TagLib.Id3v2.Tag tag = ( TagLib.Id3v2.Tag )mp3File.GetTag( TagTypes.Id3v2, true );
                var userFrame = UserTextInformationFrame.Get( tag, name, true );
                userFrame.Text = value == null ? new string[] { string.Empty } : value.Split( ';' );
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Attempt to create a string from an array of strings
        /// </summary>
        /// <returns>String.empty on failure, a good string on completion</returns>
        private string stringArrayToString( object stringArray )
        {
            try
            {
                var toBuild = new StringBuilder();
                var castedStringArray = ( string[] )stringArray;
                foreach( var item in castedStringArray )
                {
                    toBuild.AppendFormat( "{0};", item );
                }
                toBuild.Length--;
                return toBuild.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Create a string array from a string
        /// </summary>
        /// <returns>A split string based on ;</returns>
        private string[] stringToStringArray( string inputString )
        {
            return inputString?.Split( ';' );
        }
        #endregion

        #region Properties
        public string AbsolutePath
        {
            get
            {
                return mp3File.Name;
            }
        }

        public TagLib.Tag Tags
        {
            get
            {
                return mp3File.Tag;
            }
        }

        public List<TagProcessing> DirtyTags
        {
            get
            {
                return tags;
            }
        }

        public IPicture AlbumCover
        {
            get
            {
                if( mp3File.Tag.Pictures != null && mp3File.Tag.Pictures.Length >= 1 )
                {
                    return mp3File.Tag.Pictures[ 0 ];
                }
                return null;
            }
        }
        #endregion
    }
}