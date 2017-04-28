namespace TagLookup
{
    /// <summary>
    /// Necessary as a binding target    
    /// </summary>
    public class TagProcessing
    {
        #region Constructors
        public TagProcessing()
        {

        }

        public TagProcessing( string tagName, string tagValueOld, string tagValueNew )
        {
            this.tagName = tagName;
            this.tagValueOld = tagValueOld;
            this.tagValueNew = tagValueNew;
        }

        public TagProcessing( TagProcessing toClone )
        {
            tagName = toClone.tagName;
            tagValueOld = toClone.tagValueOld;
            tagValueNew = toClone.tagValueNew;
        }
        #endregion

        #region Properties
        public string tagName { get; set; }
        public string tagValueOld { get; set; }
        public string tagValueNew { get; set; }
        #endregion
    }
}
