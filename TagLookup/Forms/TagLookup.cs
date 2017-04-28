using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TagLookup
{
    public partial class TagLookup : Form
    {
        #region Fields
        private Logger log;                                             // reference to logger singleton
        private BindingList<Mp3File> itemsToProcess;                    // Binded to DataGridView ItemsToProcessQueue
        private BindingList<Website> supportedSites;                    // Binded to CheckedListBox Supported sites
        private DataProcessor dataProcessor;                            // Object that handles all processing of data
        #endregion

        #region Startup and Shutdown
        public TagLookup()
        {
            InitializeComponent();
        }

        private void TagLookup_Load( object sender, EventArgs e )
        {
            log = Logger.LoggerInstance;
            if( log != null )
            {
                log.LogTextBox = Log;
            }
            itemsToProcess = new BindingList<Mp3File>();
            BindItemsToProcessGrid();
            dataProcessor = new DataProcessor();
            if( ExposedWebsitesConfiguration.ExposedWebsitesConfigurationInstance != null )
            {
                supportedSites = new BindingList<Website>( 
                    ExposedWebsitesConfiguration.ExposedWebsitesConfigurationInstance.ExposedWebsites.Websites );
                SupportedSites.DataSource = supportedSites;
            }
        }

        private void TagLookup_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( Logger.LoggerInstance != null )
            {
                Logger.LoggerInstance.Dispose();
            }
            if( ExposedTagsConfiguration.ExposedTagsConfigurationInstance != null )
            {
                ExposedTagsConfiguration.ExposedTagsConfigurationInstance.Dispose();
            }
            if( ExposedWebsitesConfiguration.ExposedWebsitesConfigurationInstance != null )
            {
                ExposedWebsitesConfiguration.ExposedWebsitesConfigurationInstance.Dispose();
            }
        }
        #endregion

        #region Onclick Events
        /// <summary>
        /// Allows user to select directory in Music folder, then fetch all children .mp3 files
        /// </summary>
        private void AddDirectoryButton_Click( object sender, EventArgs e )
        {
            // Get User Input
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyMusic;
            folderBrowserDialog.ShowNewFolderButton = false;
            var dialogResult = folderBrowserDialog.ShowDialog();

            // Validate and add
            if( !string.IsNullOrWhiteSpace( folderBrowserDialog.SelectedPath ) )
            {
                if( log != null )
                {
                    log.Log( "Adding Directory " + folderBrowserDialog.SelectedPath.ToString() + "\n" );
                }
                var mp3Files = Directory.GetFiles( folderBrowserDialog.SelectedPath, "*.mp3", SearchOption.AllDirectories );
                AddMp3FilesToQueue( mp3Files );
            }
        }

        /// <summary>
        /// Allows user to select an mp3 file or multiple mp3 files
        /// </summary>
        private void AddFileButton_Click( object sender, EventArgs e )
        {
            // Get User Input
            var fileBrowserDialog = new OpenFileDialog();
            fileBrowserDialog.InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.MyMusic );
            fileBrowserDialog.Multiselect = true;
            fileBrowserDialog.Filter = "Music Files (.mp3)|*.mp3";
            var dialogResult = fileBrowserDialog.ShowDialog();

            // Validate and add
            AddMp3FilesToQueue( fileBrowserDialog.FileNames.Where( file => file.ToString().EndsWith( ".mp3" ) ).ToArray() );
        }

        /// <summary>
        /// Remove all objects from queue, and clears text box
        /// </summary>
        private void ClearButton_Click( object sender, EventArgs e )
        {
            Log.Clear();
            itemsToProcess.Clear();
        }

        /// <summary>
        /// Hides or Displays the log element
        /// </summary>
        private void HideLogButton_Click( object sender, EventArgs e )
        {
            if( HideLogButton.Text == "Hide Log" )
            {
                HideLogButton.Text = "Show Log";
                LogContainer.Visible = false;
                LogContainer.Parent.Height -= LogContainer.Height;
            }
            else
            {
                HideLogButton.Text = "Hide Log";
                LogContainer.Visible = true;
                LogContainer.Parent.Height += LogContainer.Height;
            }
        }

        /// <summary>
        /// Process the queue
        /// </summary>
        private void RunButton_Click( object sender, EventArgs e )
        {
            List<Mp3File> completedSuccessfullyList = new List<Mp3File>();
            foreach( var item in itemsToProcess )
            {
                if( dataProcessor.TryProcess( item, SupportedSites.CheckedItems.OfType<Website>().ToList() ) )
                    completedSuccessfullyList.Add( item );
            }
            foreach( var item in completedSuccessfullyList )
            {
                itemsToProcess.Remove( item );
                log.Log( "Successfully processed " + item + "\n" );
            }
        }

        /// <summary>
        /// Create a dialogue using the Mp3File from the binded grids data source
        /// </summary>
        private void ItemsToProcessQueue_CellMouseDoubleClick( object sender, DataGridViewCellMouseEventArgs e )
        {
            var mp3FileDialogue = new Mp3FileDialogue( itemsToProcess.ElementAt( e.RowIndex ) );
            mp3FileDialogue.Show();
        }

        /// <summary>
        /// Remove all checked items
        /// </summary>
        private void RemoveWebsiteButton_Click( object sender, EventArgs e )
        {
            foreach( var site in SupportedSites.CheckedItems.OfType<Website>().ToList() )
                supportedSites.Remove( site );
        }

        /// <summary>
        /// Spawn a dialog to create a new ExposedWebsite.Website 
        /// </summary>
        private void AddWebsiteButton_Click( object sender, EventArgs e )
        {
            var addWebsiteDialogue = new AddWebsiteDialogue( supportedSites );
            addWebsiteDialogue.Show();
        }

        /// <summary>
        /// Spawn a dialog to edit an existing ExposedWebsite.Website 
        /// </summary>
        private void SupportedSites_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            var index = SupportedSites.IndexFromPoint( e.Location );
            if( index != ListBox.NoMatches )
            {
                var addWebsiteDialogue = new AddWebsiteDialogue( supportedSites, supportedSites.ElementAt( index ) );
                addWebsiteDialogue.Show();
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Create columns and binds itemsToProcess list to DataGridView
        /// </summary>
        private void BindItemsToProcessGrid()
        {
            ItemsToProcessQueue.AutoGenerateColumns = false;

            // create the column
            var columnFilePath = new DataGridViewTextBoxColumn()
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                Name = "AbsolutePath",
                HeaderText = "File Path",
                DataPropertyName = "AbsolutePath", // Tell the column which property of Mp3File class it should use
            };

            ItemsToProcessQueue.Columns.Add( columnFilePath );
            ItemsToProcessQueue.DataSource = itemsToProcess;
        }

        /// <summary>
        /// Add the file path to the processing list, if it doesn't already exist
        /// </summary>
        /// <param name="filesToAdd">Absolute paths to mp3</param>
        private void AddMp3FilesToQueue( string[] filesToAdd )
        {
            foreach( var filePath in filesToAdd.Where( fp => !itemsToProcess.Select( mp3File => mp3File.AbsolutePath ).Contains( fp ) ) )
            {
                try
                {
                    itemsToProcess.Add( new Mp3File( filePath ) );
                    log.Log( "Adding File " + filePath + "\n" );
                }
                catch
                {
                    log.Log( "Unable to add file " + filePath + "\n" );
                }
                
            }
        }

        /// <summary>
        /// Display first embedded picture in mp3file
        /// </summary>
        private void ItemsToProcessQueue_CellEnter( object sender, DataGridViewCellEventArgs e )
        {
            if( itemsToProcess.ElementAt( e.RowIndex ).AlbumCover == null )
                return;

            using( var ms = new MemoryStream( itemsToProcess.ElementAt( e.RowIndex ).AlbumCover.Data.Data ) )
            {
                var image = Image.FromStream( ms );
                AlbumCover.Image = image;
            }
        }
        #endregion
    }
}
