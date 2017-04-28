using System.ComponentModel;
using System.Windows.Forms;

namespace TagLookup
{
    public partial class AddWebsiteDialogue : Form
    {
        #region Fields
        private Website website;
        private BindingList<Website> supportedSites;
        private bool newWebsite;
        #endregion

        #region Startup and Shutdown
        public AddWebsiteDialogue( BindingList<Website> supportedSites, Website websiteEntry = null )
        {
            InitializeComponent();

            if( websiteEntry == null )
            {
                website = new Website();
                newWebsite = true;
            }
            else
            {
                website = websiteEntry;
                Text = website.Name;
                newWebsite = false;
            }
            
            NameTextbox.Text = website.Name;
            UriList.DataSource = new BindingList<Website.Uri>( website.uriElements );
            RegexList.DataSource = new BindingList<Website.RegularExpression>( website.regexElements );
            this.supportedSites = supportedSites;
        }

        private void AddWebsiteDialogue_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( !string.IsNullOrEmpty( NameTextbox.Text ) && newWebsite )
            {
                website.Name = NameTextbox.Text;
                supportedSites.Add( website );
            }
        }
        #endregion
    }
}
