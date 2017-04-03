namespace TagLookup
{
    /// <summary>
    /// Container class to represent a single mp3 file
    /// </summary>
    public class Mp3File
    {
        #region Fields
        private string absolutePath;
        #endregion

        #region Constructors
        public Mp3File( string value )
        {
            absolutePath = value;
        }
        #endregion

        #region Accessors
        public string AbsolutePath
        {
            get
            {
                return absolutePath;
            }
        }
        #endregion
    }
}