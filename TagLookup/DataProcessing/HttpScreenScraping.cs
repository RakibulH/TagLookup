using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace TagLookup
{
    class HttpScreenScraping
    {
        #region Fields
        private WebClient webClient;                    // Not going to bother doing fine grained protocol control
        private const string toComplete = @"{(.*)}";    // Used to generate user uris
        private string completedUri;                    // Cache previous uri
        private string completedPage;                   // Cache previous downloaded page
        #endregion

        #region Constructors
        public HttpScreenScraping()
        {
            webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            completedUri = string.Empty;
            completedPage = string.Empty;
        }

        ~HttpScreenScraping()
        {
            webClient.Dispose();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Using user provided parsing information, attempt to map retrieved data to mp3 file
        /// </summary>
        /// <param name="itemToProcess">The mp3 file wrapper</param>
        /// <param name="website">An exposed websites node</param>
        public void Process( Mp3File itemToProcess, Website website )
        {
            // Only use first valid source for parsing to avoid overwriting data and potentially unnecessary parsing
            foreach( var uri in website.uriElements )
            {
                var completedUri = CompleteUri( uri.uri, itemToProcess.DirtyTags );
                if( completedUri.Equals( this.completedUri ) )
                {
                    ProcessRegex( website.regexElements, itemToProcess.DirtyTags );
                    break;
                }

                if( Uri.IsWellFormedUriString( completedUri, UriKind.Absolute ) )
                {
                    try
                    {
                        // Is this were to be asynchronous, we'd have to introduce a mechanism 
                        // by which processing is done by a grouping of albums instead of per
                        // mp3 file. In such a case, you could process them in parallel as generally
                        // they would be using the same source.
                        var completedPage = webClient.DownloadString( completedUri );
                        this.completedUri = completedUri;
                        this.completedPage = completedPage;
                        ProcessRegex( website.regexElements, itemToProcess.DirtyTags );
                        break;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Process every user defined regex, if it's invalid, remove the regex
        /// </summary>
        /// <param name="regexElements">Regex elements define control</param>
        /// <param name="dirtyTags">Tags to where to map</param>
        private void ProcessRegex( List<Website.RegularExpression> regexElements, List<TagProcessing> dirtyTags )
        {
            List<Website.RegularExpression> invalidRegexElements = null;

            // Process all regex
            foreach( var regex in regexElements )
            {
                if( string.IsNullOrEmpty( regex.Regex ) )
                    continue;

                try
                {
                    if( regex.SelectMultiple )
                    {
                        var matches = Regex.Matches( completedPage, regex.Regex );
                        foreach( Match match in matches )
                            MatchToTagProcessingList( regex, match, dirtyTags );
                    }
                    else
                    {
                        var match = Regex.Match( completedPage, regex.Regex );
                        if( match.Success )
                            MatchToTagProcessingList( regex, match, dirtyTags );
                    }
                }
                catch // invalid regex
                {
                    if( invalidRegexElements == null )
                        invalidRegexElements = new List<Website.RegularExpression>();
                    invalidRegexElements.Add( regex );
                    continue;
                }
            }

            // Remove invalid regex
            if( invalidRegexElements != null )
                invalidRegexElements.ForEach( x => regexElements.Remove( x ) );
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// Uses tags to replace all {tag} value to make a uri
        /// </summary>
        /// <param name="uri">The user uri to complete</param>
        /// <param name="tags">The tags from where you take values</param>
        /// <returns>The completed uri</returns>
        private string CompleteUri( string uri, List<TagProcessing> tags )
        {
            var completedUri = uri;
            var regex = new Regex( toComplete, RegexOptions.Singleline );
            var matches = regex.Matches( uri );

            foreach( Match match in matches )
            {
                var tagToSearchFor = match.Value.Substring( 1, match.Value.Length - 2 );
                var correction = tags.Where( x => x.tagName == tagToSearchFor ).FirstOrDefault();
                if( correction != null )
                {
                    completedUri = completedUri.Replace( match.Value, correction.tagValueOld );
                }
            }
            return completedUri;
        }

        /// <summary>
        /// Map a single match to a list of tag processing objects
        /// </summary>
        /// <param name="regex">Used to find target</param>
        /// <param name="match">For getting captured string</param>
        /// <param name="dirtyTags">List to mutate</param>
        private void MatchToTagProcessingList( Website.RegularExpression regex, Match match, List<TagProcessing> dirtyTags )
        {
            var targetTag = dirtyTags.Where( tag => tag.tagName == regex.TargetTag ).FirstOrDefault();
            if( targetTag == null )
            {
                dirtyTags.Add( new TagProcessing( regex.TargetTag, string.Empty, match.Groups[ 1 ].Value ) );
            }
            else if( regex.Append )
            {
                targetTag.tagValueNew += targetTag.tagValueNew == string.Empty ? "" : ";";
                targetTag.tagValueNew += match.Groups[ 1 ].Value;
            }
            else
            {
                targetTag.tagValueNew = match.Groups[ 1 ].Value;
            }
        }
        #endregion
    }
}
