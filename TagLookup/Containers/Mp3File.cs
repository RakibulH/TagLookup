namespace TagLookup
{
    class Mp3File
    {
        private string absolutePath;
        public Mp3File( string value )
        {
            absolutePath = value;
        }
        public string AbsolutePath
        {
            get
            {
                return absolutePath;
            }
        }
    }
}