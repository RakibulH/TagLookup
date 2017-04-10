using System;
using System.Text;
using TagLib;
using TagLib.Id3v2;

namespace TagLookup
{
    /// <summary>
    /// Container class to represent a single mp3 file
    /// </summary>
    public class Mp3File
    {
        #region Fields
        public File mp3File;
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
        }
        #endregion

        #region Methods
        /// <summary>
        /// Attempt to read a private frame
        /// </summary>
        /// <param name="name">name of private frame</param>
        /// <returns>string value on success, string.empty on failure</returns>
        public string ReadPrivateFrame( string name )
        {
            try
            {
                TagLib.Id3v2.Tag tag = ( TagLib.Id3v2.Tag )mp3File.GetTag( TagTypes.Id3v2 );
                var privateFrame = PrivateFrame.Get( tag, name, false );
                return Encoding.Unicode.GetString( privateFrame.PrivateData.Data );
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Attempt to write a private frame
        /// </summary>
        /// <returns>true on success, false on failure</returns>
        public bool WritePrivateFrame( string name, string value )
        {
            try
            {
                TagLib.Id3v2.Tag tag = ( TagLib.Id3v2.Tag )mp3File.GetTag( TagTypes.Id3v2, true );
                var privateFrame = PrivateFrame.Get( tag, name, true );
                privateFrame.PrivateData = Encoding.Unicode.GetBytes( value );
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Accessors
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
                return mp3File.GetTag( TagTypes.Id3v2 );
            }
        }
        #endregion
    }
}