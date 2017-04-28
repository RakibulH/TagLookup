using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace TagLookup
{
    public partial class Mp3FileDialogue : Form
    {
        #region Fields
        private Mp3File mp3File;                        // reference to mp3File wrapper
        private ExposedTags exposedTags;                // reference to exposed tags contained in singleton
        private BindingList<TagProcessing> tags;        // Binded to DataGridView TagsGrid
        private int addedTags = 0;                      // Counter to know when to unregister listener
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
            exposedTags = ExposedTagsConfiguration.ExposedTagsConfigurationInstance.ExposedTags;
            tags = new BindingList<TagProcessing>( mp3File.DirtyTags );
            TagsGrid.AutoGenerateColumns = false;
            TagsGrid.DataSource = tags;
        }
        #endregion

        #region OnClick Events
        /// <summary>
        /// Reset tags collection
        /// </summary>
        private void ResetToOldTagsButton_Click( object sender, EventArgs e )
        {
            mp3File.ResetDirtyTags();
            tags.ResetBindings();
            TagsGrid.Refresh();
        }

        /// <summary>
        /// Add an item
        /// </summary>
        private void AddTagButton_Click( object sender, EventArgs e )
        {
            tags.Add( new TagProcessing() );
            TagsGrid.Rows[ TagsGrid.Rows.Count -1 ].Cells[ "TagName" ].ReadOnly = false;
            TagsGrid.CellEndEdit += TagsGrid_CellEndEdit;
            addedTags++;
        }

        /// <summary>
        /// Lookup for preexisting value if present
        /// </summary>
        private void TagsGrid_CellEndEdit( object sender, DataGridViewCellEventArgs e )
        {
            var tagNameValue = TagsGrid.Rows[ e.RowIndex ].Cells[ e.ColumnIndex ].Value;
            if( tagNameValue != null && !string.IsNullOrEmpty( tagNameValue.ToString() ) )
            {
                string tmp;
                mp3File.TryReadValue( tagNameValue.ToString(), ExposedTags.IsPrivateOrUserFrame( tagNameValue.ToString() ), out tmp );
                TagsGrid.Rows[ e.RowIndex ].Cells[ "TagValueOld" ].Value = tmp;
                TagsGrid.Rows[ e.RowIndex ].Cells[ e.ColumnIndex ].ReadOnly = true;
                addedTags--;
                if( addedTags == 0 )
                {
                    TagsGrid.CellEndEdit -= TagsGrid_CellEndEdit;
                }
            }
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        private void RemoveTagButton_Click( object sender, EventArgs e )
        {
            foreach( DataGridViewRow item in TagsGrid.SelectedRows )
            {
                TagsGrid.Rows[ item.Index ].Cells[ "TagValueNew" ].Value = string.Empty;
                TagsGrid.Rows.RemoveAt( item.Index );
            }

            foreach( DataGridViewCell cell in TagsGrid.SelectedCells )
            {
                if( cell.Selected )
                {
                    TagsGrid.Rows[ cell.RowIndex ].Cells[ "TagValueNew" ].Value = string.Empty;
                    TagsGrid.Rows.RemoveAt( cell.RowIndex );
                }
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

                if( ExposedTags.IsPrivateOrUserFrame( name ) )
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
            mp3File.InitializeDirtyTags();
            tags.ResetBindings();
        }

        /// <summary>
        /// Save and exit
        /// </summary>
        private void SaveChangesButton_Click( object sender, EventArgs e )
        {
            mp3File.Save();
            Close();
        }
        #endregion
    }
}
