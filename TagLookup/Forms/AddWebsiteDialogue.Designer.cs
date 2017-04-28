namespace TagLookup
{
    partial class AddWebsiteDialogue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Panel Mp3FilePropertiesContainer;
            this.WebsiteContainer = new System.Windows.Forms.Panel();
            this.TablesContainer = new System.Windows.Forms.TableLayoutPanel();
            this.RegexList = new System.Windows.Forms.DataGridView();
            this.UriList = new System.Windows.Forms.DataGridView();
            this.Uri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameContainer = new System.Windows.Forms.Panel();
            this.NameTextboxContainer = new System.Windows.Forms.Panel();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.NameLabelContainer = new System.Windows.Forms.Panel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SelectMultiple = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Append = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RegularExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Mp3FilePropertiesContainer = new System.Windows.Forms.Panel();
            Mp3FilePropertiesContainer.SuspendLayout();
            this.WebsiteContainer.SuspendLayout();
            this.TablesContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegexList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UriList)).BeginInit();
            this.NameContainer.SuspendLayout();
            this.NameTextboxContainer.SuspendLayout();
            this.NameLabelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mp3FilePropertiesContainer
            // 
            Mp3FilePropertiesContainer.Controls.Add(this.WebsiteContainer);
            Mp3FilePropertiesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            Mp3FilePropertiesContainer.Location = new System.Drawing.Point(0, 0);
            Mp3FilePropertiesContainer.Name = "Mp3FilePropertiesContainer";
            Mp3FilePropertiesContainer.Size = new System.Drawing.Size(1130, 581);
            Mp3FilePropertiesContainer.TabIndex = 2;
            // 
            // WebsiteContainer
            // 
            this.WebsiteContainer.Controls.Add(this.TablesContainer);
            this.WebsiteContainer.Controls.Add(this.NameContainer);
            this.WebsiteContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebsiteContainer.Location = new System.Drawing.Point(0, 0);
            this.WebsiteContainer.Name = "WebsiteContainer";
            this.WebsiteContainer.Size = new System.Drawing.Size(1130, 581);
            this.WebsiteContainer.TabIndex = 1;
            // 
            // TablesContainer
            // 
            this.TablesContainer.ColumnCount = 2;
            this.TablesContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.15929F));
            this.TablesContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.84071F));
            this.TablesContainer.Controls.Add(this.RegexList, 1, 0);
            this.TablesContainer.Controls.Add(this.UriList, 0, 0);
            this.TablesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablesContainer.Location = new System.Drawing.Point(0, 28);
            this.TablesContainer.Name = "TablesContainer";
            this.TablesContainer.RowCount = 1;
            this.TablesContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablesContainer.Size = new System.Drawing.Size(1130, 553);
            this.TablesContainer.TabIndex = 3;
            // 
            // RegexList
            // 
            this.RegexList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RegexList.BackgroundColor = System.Drawing.Color.White;
            this.RegexList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RegexList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectMultiple,
            this.Append,
            this.RegularExpression,
            this.TargetTag});
            this.RegexList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegexList.Location = new System.Drawing.Point(388, 3);
            this.RegexList.Name = "RegexList";
            this.RegexList.RowTemplate.Height = 24;
            this.RegexList.Size = new System.Drawing.Size(739, 547);
            this.RegexList.TabIndex = 1;
            // 
            // UriList
            // 
            this.UriList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UriList.BackgroundColor = System.Drawing.Color.White;
            this.UriList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UriList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Uri});
            this.UriList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UriList.Location = new System.Drawing.Point(3, 3);
            this.UriList.Name = "UriList";
            this.UriList.RowTemplate.Height = 24;
            this.UriList.Size = new System.Drawing.Size(379, 547);
            this.UriList.TabIndex = 0;
            // 
            // Uri
            // 
            this.Uri.DataPropertyName = "uri";
            this.Uri.HeaderText = "Uri";
            this.Uri.Name = "Uri";
            // 
            // NameContainer
            // 
            this.NameContainer.Controls.Add(this.NameTextboxContainer);
            this.NameContainer.Controls.Add(this.NameLabelContainer);
            this.NameContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameContainer.Location = new System.Drawing.Point(0, 0);
            this.NameContainer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.NameContainer.Name = "NameContainer";
            this.NameContainer.Padding = new System.Windows.Forms.Padding(3);
            this.NameContainer.Size = new System.Drawing.Size(1130, 28);
            this.NameContainer.TabIndex = 2;
            // 
            // NameTextboxContainer
            // 
            this.NameTextboxContainer.Controls.Add(this.NameTextbox);
            this.NameTextboxContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameTextboxContainer.Location = new System.Drawing.Point(52, 3);
            this.NameTextboxContainer.Name = "NameTextboxContainer";
            this.NameTextboxContainer.Size = new System.Drawing.Size(1075, 22);
            this.NameTextboxContainer.TabIndex = 1;
            // 
            // NameTextbox
            // 
            this.NameTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameTextbox.Location = new System.Drawing.Point(0, 0);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(1075, 22);
            this.NameTextbox.TabIndex = 0;
            // 
            // NameLabelContainer
            // 
            this.NameLabelContainer.Controls.Add(this.NameLabel);
            this.NameLabelContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.NameLabelContainer.Location = new System.Drawing.Point(3, 3);
            this.NameLabelContainer.Name = "NameLabelContainer";
            this.NameLabelContainer.Size = new System.Drawing.Size(49, 22);
            this.NameLabelContainer.TabIndex = 0;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.NameLabel.Location = new System.Drawing.Point(4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(45, 17);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name";
            // 
            // SelectMultiple
            // 
            this.SelectMultiple.DataPropertyName = "SelectMultiple";
            this.SelectMultiple.FillWeight = 50F;
            this.SelectMultiple.HeaderText = "Select Multiple";
            this.SelectMultiple.Name = "SelectMultiple";
            this.SelectMultiple.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectMultiple.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Append
            // 
            this.Append.DataPropertyName = "Append";
            this.Append.FillWeight = 50F;
            this.Append.HeaderText = "Append";
            this.Append.Name = "Append";
            // 
            // RegularExpression
            // 
            this.RegularExpression.DataPropertyName = "Regex";
            this.RegularExpression.HeaderText = "Regular Expression";
            this.RegularExpression.Name = "RegularExpression";
            // 
            // TargetTag
            // 
            this.TargetTag.DataPropertyName = "TargetTag";
            this.TargetTag.HeaderText = "Target Tag";
            this.TargetTag.Name = "TargetTag";
            // 
            // AddWebsiteDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 581);
            this.Controls.Add(Mp3FilePropertiesContainer);
            this.Name = "AddWebsiteDialogue";
            this.Text = "Add Website";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddWebsiteDialogue_FormClosing);
            Mp3FilePropertiesContainer.ResumeLayout(false);
            this.WebsiteContainer.ResumeLayout(false);
            this.TablesContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RegexList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UriList)).EndInit();
            this.NameContainer.ResumeLayout(false);
            this.NameTextboxContainer.ResumeLayout(false);
            this.NameTextboxContainer.PerformLayout();
            this.NameLabelContainer.ResumeLayout(false);
            this.NameLabelContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WebsiteContainer;
        private System.Windows.Forms.Panel NameContainer;
        private System.Windows.Forms.Panel NameTextboxContainer;
        private System.Windows.Forms.Panel NameLabelContainer;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TableLayoutPanel TablesContainer;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.DataGridView RegexList;
        private System.Windows.Forms.DataGridView UriList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uri;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectMultiple;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Append;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegularExpression;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetTag;
    }
}