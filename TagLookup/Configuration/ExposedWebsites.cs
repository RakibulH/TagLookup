using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace TagLookup
{
    /// <summary>
    /// Interfaces the "ExposedWebsites" xml document
    /// </summary>
    [XmlRoot( "Websites" )]
    public class ExposedWebsites
    {
        #region Constructors
        /// <summary>
        /// Necessary for serialization
        /// </summary>
        public ExposedWebsites()
        {
        }
        #endregion

        #region Properties
        [XmlElement( "Website" )]
        public List<Website> Websites;
        #endregion
    }

    /// <summary>
    /// Exposes a single xml node from the "ExposedWebsites" xml document
    /// </summary>
    [XmlType]
    public class Website
    {
        #region Constructors
        /// <summary>
        /// Necessary for serialization
        /// </summary>
        public Website()
        {
            uriElements = new List<Uri>();
            regexElements = new List<RegularExpression>();
            Name = string.Empty;
        }
        #endregion

        #region Properties
        [XmlAttribute( "Name" )]
        public string Name { get; set; }

        [XmlElement( "Uri" )]
        public List<Uri> uriElements { get; set; }

        [XmlElement( "RegularExpression" )]
        public List<RegularExpression> regexElements;
        #endregion

        #region Internal Objects
        [XmlType]
        public class RegularExpression
        {
            #region Constructors
            public RegularExpression()
            {
            }

            public RegularExpression( bool SelectMultiple = false, bool Append = false, string Regex = "", string TargetTag = "" )
            {
                this.SelectMultiple = SelectMultiple;
                this.Append = Append;
                this.TargetTag = TargetTag;
                this.Regex = Regex;
            }
            #endregion

            #region Properties
            [XmlAttribute( "SelectMultiple" )]
            public bool SelectMultiple { get; set; }

            [XmlAttribute( "Append" )]
            public bool Append { get; set; }

            [XmlAttribute( "TargetTag" )]
            public string TargetTag { get; set; }

            [XmlAttribute( "Regex" )]
            public string Regex { get; set; }
            #endregion
        }

        [XmlType]
        public class Uri
        {
            #region Constructors
            public Uri()
            {
            }
            #endregion

            #region Properties
            [XmlText]
            public string uri { get; set; }
            #endregion
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
