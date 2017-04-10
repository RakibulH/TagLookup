using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TagLookup
{
    public partial class Mp3FileDialogue : Form
    {
        #region Fields
        private Logger log;                             // reference to logger singleton
        private Mp3File mp3File;                        // reference to mp3File wrapper
        private ExposedTags exposedTags;                // reference to exposed tags contained in singleton
        private BindingList<TagProcessing> tags;        // Binded to DataGridView TagsGrid
        private List<TagProcessing> copy;               // A non working copy for fast resets
        #endregion

        #region Startup and Shutdown
        /// <summary>
        /// Set defaults and bind grid
        /// </summary>
        /// <param name="mp3File">mp3file is used only for tags</param>
        public Mp3FileDialogue( Mp3File mp3File )
        {
            InitializeComponent();
            this.mp3File = mp3File;
            Text = Path.GetFileName( mp3File.AbsolutePath );
            log = Logger.LoggerInstance;
            exposedTags = ExposedTagsConfiguration.ExposedTagsConfigurationInstance.ExposedTags;
            InitializeBindingList();
            BindItemsToTagsGrid();
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Build internal object to expose based on xml config
        /// </summary>
        private void InitializeBindingList()
        {
            if( tags == null )
            {
                tags = new BindingList<TagProcessing>();
            }
            else
            {
                tags.Clear();
            }
            
            if( copy == null )
            {
                copy = new List<TagProcessing>();
            }
            else
            {
                copy.Clear();
            }
            
            foreach( var tag in exposedTags.Tags )
            {
                var name = tag.Name;
                try
                {
                    if( string.IsNullOrEmpty( name ) )
                    {
                        continue;
                    }

                    if( !tag.PrivateFrame )
                    {
                        var obj = mp3File.Tags.GetType().GetProperty( tag.Name ).GetValue( mp3File.Tags, null );
                        string arrayParser = null;
                        if( mp3File.Tags.GetType().GetProperty( tag.Name ).PropertyType == typeof( string[] ) )
                            arrayParser = stringArrayToString( obj );
                        
                        if( obj == null )
                        {
                            tags.Add( new TagProcessing( name, string.Empty, string.Empty ) );
                        }
                        else if( arrayParser != null )
                        {
                            tags.Add( new TagProcessing( name, arrayParser, arrayParser ) );
                        }
                        else
                        {
                            tags.Add( new TagProcessing( name, obj.ToString(), obj.ToString() ) );
                        }
                    }
                    else
                    {
                        var privateFrameValue = mp3File.ReadPrivateFrame( name );
                        tags.Add( new TagProcessing( name, privateFrameValue, privateFrameValue ) );
                    }    
                }
                catch
                {
                    // emit    
                }
            }

            copy = tags.ToList();
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
                    toBuild.AppendFormat( "{0};",item );
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
            return inputString.Split( ';' );
        }

        /// <summary>
        /// Make the grid programatically 
        /// </summary>
        private void BindItemsToTagsGrid()
        {
            TagsGrid.AutoGenerateColumns = false;

            var columnTagName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                Name = "TagName",
                HeaderText = "Tag Name",
                DataPropertyName = "tagName",
                ReadOnly = true
            };
            TagsGrid.Columns.Add( columnTagName );

            var columnTagValueOld = new DataGridViewTextBoxColumn()
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                Name = "TagValueOld",
                HeaderText = "Current Tag Value",
                DataPropertyName = "tagValueOld",
                ReadOnly = true
            };
            TagsGrid.Columns.Add( columnTagValueOld );

            var columnTagValueNew = new DataGridViewTextBoxColumn()
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                Name = "TagValueNew",
                HeaderText = "New Tag Value",
                DataPropertyName = "tagValuenew"
            };
            TagsGrid.Columns.Add( columnTagValueNew );

            TagsGrid.AllowUserToAddRows = false;
            TagsGrid.DataSource = tags;
        }
        #endregion

        #region OnClick Events
        /// <summary>
        /// Reset tags collection
        /// </summary>
        private void ResetToOldTagsButton_Click( object sender, EventArgs e )
        {
            tags = null;
            tags = new BindingList<TagProcessing>( copy );  // removes all new tags
            foreach( var tag in tags )                      // removes all changes
            {
                tag.tagValueNew = tag.tagValueOld;
            }
            TagsGrid.DataSource = tags;
            TagsGrid.Refresh();
        }

        /// <summary>
        /// Add an item
        /// </summary>
        private void AddTagButton_Click( object sender, EventArgs e )
        {
            tags.Add( new TagProcessing() );
            TagsGrid.Rows[ TagsGrid.Rows.Count -1 ].Cells[ "TagName" ].ReadOnly = false;
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        private void RemoveTagButton_Click( object sender, EventArgs e )
        {
            foreach( DataGridViewRow item in TagsGrid.SelectedRows )
            {
                TagsGrid.Rows.RemoveAt( item.Index );
            }

            foreach( DataGridViewCell cell in TagsGrid.SelectedCells )
            {
                if( cell.Selected )
                    TagsGrid.Rows.RemoveAt( cell.RowIndex );
            }
        }
        
        /// <summary>
        /// Changes will persist to disk after serialization, for now change singleton
        /// </summary>
        private void SaveCurrentAsDefaultsButton_Click( object sender, EventArgs e )
        {
            exposedTags.Tags.Clear();
            foreach( var tag in tags )
            {
                var name = tag.tagName;

                if( exposedTags.IsPrivateFrame( name ) )
                {
                    exposedTags.Tags.Add( new ExposedTags.Tag( name, true ) );
                }
                else
                {
                    exposedTags.Tags.Add( new ExposedTags.Tag( name ) );
                }
            }
        }

        /// <summary>
        /// Expose only the default read writeable tags
        /// </summary>
        private void ResetToDefaultTagsButton_Click( object sender, EventArgs e )
        {
            exposedTags.CreateDefault();
            InitializeBindingList();
        }

        /// <summary>
        /// Write all old to new and save
        /// </summary>
        private void SaveChangesButton_Click( object sender, EventArgs e )
        {   //.Where( x => !string.Equals( x.tagValueNew, x.tagValueOld )
            foreach( var tag in tags.Where( x => !string.Equals( x.tagValueNew, x.tagValueOld ) ) )
            {
                bool success = false;
                foreach( var propertyInfo in typeof( TagLib.Tag ).GetProperties() )
                {
                    if( propertyInfo.CanRead && propertyInfo.CanWrite && string.Equals( propertyInfo.Name, tag.tagName ) )
                    {
                        if( propertyInfo.PropertyType == typeof( string[] ) )
                        {
                            mp3File.Tags.GetType().GetProperty( tag.tagName ).
                                SetValue( mp3File.Tags, stringToStringArray( tag.tagValueNew ) );
                        }
                        else if( propertyInfo.PropertyType == typeof( UInt32 ) )
                        {
                            UInt32 temp;
                            if( UInt32.TryParse( tag.tagValueNew, out temp ) )
                            {
                                mp3File.Tags.GetType().GetProperty( tag.tagName ).
                                    SetValue( mp3File.Tags, temp );
                            }
                            else
                            {
                                continue;
                            }   
                        }
                        else
                        {
                            mp3File.Tags.GetType().GetProperty( tag.tagName ).
                                SetValue( mp3File.Tags, tag.tagValueNew );
                        }

                        success = true;
                        break;
                    }
                }

                if( !success )
                    mp3File.WritePrivateFrame( tag.tagName, tag.tagValueNew );
            }
            mp3File.mp3File.Save();
            Close();
        }
        #endregion
    }
}
