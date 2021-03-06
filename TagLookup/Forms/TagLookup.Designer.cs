﻿namespace TagLookup
{
    partial class TagLookup
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
            this.SupportedSitesContainer = new System.Windows.Forms.Panel();
            this.WebsiteButtonsContainer = new System.Windows.Forms.Panel();
            this.RemoveWebsiteButton = new System.Windows.Forms.Button();
            this.AddWebsiteButton = new System.Windows.Forms.Button();
            this.AlbumCoverContainer = new System.Windows.Forms.Panel();
            this.AlbumCover = new System.Windows.Forms.PictureBox();
            this.SupportedSites = new System.Windows.Forms.CheckedListBox();
            this.ItemsToProcessQueueContainer = new System.Windows.Forms.Panel();
            this.ItemsToProcessQueue = new System.Windows.Forms.DataGridView();
            this.LogContainer = new System.Windows.Forms.Panel();
            this.Log = new System.Windows.Forms.TextBox();
            this.ButtonsContainer = new System.Windows.Forms.Panel();
            this.RunButtonContainer = new System.Windows.Forms.Panel();
            this.RunButton = new System.Windows.Forms.Button();
            this.ClearButtonContainer = new System.Windows.Forms.Panel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.HideLogButtonContainer = new System.Windows.Forms.Panel();
            this.HideLogButton = new System.Windows.Forms.Button();
            this.AddFileButtonContainer = new System.Windows.Forms.Panel();
            this.AddFileButton = new System.Windows.Forms.Button();
            this.AddDirectoryButtonContainer = new System.Windows.Forms.Panel();
            this.AddDirectoryButton = new System.Windows.Forms.Button();
            this.SupportedSitesContainer.SuspendLayout();
            this.WebsiteButtonsContainer.SuspendLayout();
            this.AlbumCoverContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumCover)).BeginInit();
            this.ItemsToProcessQueueContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsToProcessQueue)).BeginInit();
            this.LogContainer.SuspendLayout();
            this.ButtonsContainer.SuspendLayout();
            this.RunButtonContainer.SuspendLayout();
            this.ClearButtonContainer.SuspendLayout();
            this.HideLogButtonContainer.SuspendLayout();
            this.AddFileButtonContainer.SuspendLayout();
            this.AddDirectoryButtonContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SupportedSitesContainer
            // 
            this.SupportedSitesContainer.Controls.Add(this.WebsiteButtonsContainer);
            this.SupportedSitesContainer.Controls.Add(this.AlbumCoverContainer);
            this.SupportedSitesContainer.Controls.Add(this.SupportedSites);
            this.SupportedSitesContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.SupportedSitesContainer.Location = new System.Drawing.Point(0, 0);
            this.SupportedSitesContainer.Margin = new System.Windows.Forms.Padding(0);
            this.SupportedSitesContainer.MinimumSize = new System.Drawing.Size(151, 538);
            this.SupportedSitesContainer.Name = "SupportedSitesContainer";
            this.SupportedSitesContainer.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.SupportedSitesContainer.Size = new System.Drawing.Size(151, 538);
            this.SupportedSitesContainer.TabIndex = 0;
            // 
            // WebsiteButtonsContainer
            // 
            this.WebsiteButtonsContainer.Controls.Add(this.RemoveWebsiteButton);
            this.WebsiteButtonsContainer.Controls.Add(this.AddWebsiteButton);
            this.WebsiteButtonsContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WebsiteButtonsContainer.Location = new System.Drawing.Point(5, 142);
            this.WebsiteButtonsContainer.Name = "WebsiteButtonsContainer";
            this.WebsiteButtonsContainer.Size = new System.Drawing.Size(146, 30);
            this.WebsiteButtonsContainer.TabIndex = 2;
            // 
            // RemoveWebsiteButton
            // 
            this.RemoveWebsiteButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.RemoveWebsiteButton.Location = new System.Drawing.Point(71, 0);
            this.RemoveWebsiteButton.Name = "RemoveWebsiteButton";
            this.RemoveWebsiteButton.Size = new System.Drawing.Size(75, 30);
            this.RemoveWebsiteButton.TabIndex = 1;
            this.RemoveWebsiteButton.Text = "Remove";
            this.RemoveWebsiteButton.UseVisualStyleBackColor = true;
            this.RemoveWebsiteButton.Click += new System.EventHandler(this.RemoveWebsiteButton_Click);
            // 
            // AddWebsiteButton
            // 
            this.AddWebsiteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddWebsiteButton.Location = new System.Drawing.Point(0, 0);
            this.AddWebsiteButton.Name = "AddWebsiteButton";
            this.AddWebsiteButton.Size = new System.Drawing.Size(75, 30);
            this.AddWebsiteButton.TabIndex = 0;
            this.AddWebsiteButton.Text = "Add";
            this.AddWebsiteButton.UseVisualStyleBackColor = true;
            this.AddWebsiteButton.Click += new System.EventHandler(this.AddWebsiteButton_Click);
            // 
            // AlbumCoverContainer
            // 
            this.AlbumCoverContainer.Controls.Add(this.AlbumCover);
            this.AlbumCoverContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlbumCoverContainer.Location = new System.Drawing.Point(5, 5);
            this.AlbumCoverContainer.Name = "AlbumCoverContainer";
            this.AlbumCoverContainer.Padding = new System.Windows.Forms.Padding(3);
            this.AlbumCoverContainer.Size = new System.Drawing.Size(146, 167);
            this.AlbumCoverContainer.TabIndex = 1;
            // 
            // AlbumCover
            // 
            this.AlbumCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlbumCover.ErrorImage = null;
            this.AlbumCover.InitialImage = null;
            this.AlbumCover.Location = new System.Drawing.Point(3, 3);
            this.AlbumCover.Name = "AlbumCover";
            this.AlbumCover.Size = new System.Drawing.Size(140, 161);
            this.AlbumCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlbumCover.TabIndex = 0;
            this.AlbumCover.TabStop = false;
            // 
            // SupportedSites
            // 
            this.SupportedSites.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SupportedSites.FormattingEnabled = true;
            this.SupportedSites.Location = new System.Drawing.Point(5, 172);
            this.SupportedSites.Name = "SupportedSites";
            this.SupportedSites.Size = new System.Drawing.Size(146, 361);
            this.SupportedSites.TabIndex = 0;
            this.SupportedSites.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SupportedSites_MouseDoubleClick);
            // 
            // ItemsToProcessQueueContainer
            // 
            this.ItemsToProcessQueueContainer.Controls.Add(this.ItemsToProcessQueue);
            this.ItemsToProcessQueueContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemsToProcessQueueContainer.Location = new System.Drawing.Point(151, 0);
            this.ItemsToProcessQueueContainer.MinimumSize = new System.Drawing.Size(1008, 487);
            this.ItemsToProcessQueueContainer.Name = "ItemsToProcessQueueContainer";
            this.ItemsToProcessQueueContainer.Padding = new System.Windows.Forms.Padding(5);
            this.ItemsToProcessQueueContainer.Size = new System.Drawing.Size(1008, 487);
            this.ItemsToProcessQueueContainer.TabIndex = 1;
            // 
            // ItemsToProcessQueue
            // 
            this.ItemsToProcessQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ItemsToProcessQueue.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ItemsToProcessQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsToProcessQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsToProcessQueue.Location = new System.Drawing.Point(5, 5);
            this.ItemsToProcessQueue.Margin = new System.Windows.Forms.Padding(0);
            this.ItemsToProcessQueue.Name = "ItemsToProcessQueue";
            this.ItemsToProcessQueue.RowTemplate.Height = 24;
            this.ItemsToProcessQueue.Size = new System.Drawing.Size(998, 477);
            this.ItemsToProcessQueue.TabIndex = 0;
            this.ItemsToProcessQueue.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsToProcessQueue_CellEnter);
            this.ItemsToProcessQueue.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ItemsToProcessQueue_CellMouseDoubleClick);
            // 
            // LogContainer
            // 
            this.LogContainer.Controls.Add(this.Log);
            this.LogContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogContainer.Location = new System.Drawing.Point(0, 538);
            this.LogContainer.MinimumSize = new System.Drawing.Size(1159, 152);
            this.LogContainer.Name = "LogContainer";
            this.LogContainer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.LogContainer.Size = new System.Drawing.Size(1159, 152);
            this.LogContainer.TabIndex = 1;
            // 
            // Log
            // 
            this.Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log.Location = new System.Drawing.Point(5, 0);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(1149, 147);
            this.Log.TabIndex = 0;
            // 
            // ButtonsContainer
            // 
            this.ButtonsContainer.Controls.Add(this.RunButtonContainer);
            this.ButtonsContainer.Controls.Add(this.ClearButtonContainer);
            this.ButtonsContainer.Controls.Add(this.HideLogButtonContainer);
            this.ButtonsContainer.Controls.Add(this.AddFileButtonContainer);
            this.ButtonsContainer.Controls.Add(this.AddDirectoryButtonContainer);
            this.ButtonsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsContainer.Location = new System.Drawing.Point(151, 487);
            this.ButtonsContainer.MinimumSize = new System.Drawing.Size(1008, 51);
            this.ButtonsContainer.Name = "ButtonsContainer";
            this.ButtonsContainer.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.ButtonsContainer.Size = new System.Drawing.Size(1008, 51);
            this.ButtonsContainer.TabIndex = 1;
            // 
            // RunButtonContainer
            // 
            this.RunButtonContainer.Controls.Add(this.RunButton);
            this.RunButtonContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunButtonContainer.Location = new System.Drawing.Point(802, 0);
            this.RunButtonContainer.Name = "RunButtonContainer";
            this.RunButtonContainer.Size = new System.Drawing.Size(206, 46);
            this.RunButtonContainer.TabIndex = 6;
            // 
            // RunButton
            // 
            this.RunButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.RunButton.Location = new System.Drawing.Point(0, 0);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(201, 46);
            this.RunButton.TabIndex = 0;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // ClearButtonContainer
            // 
            this.ClearButtonContainer.Controls.Add(this.ClearButton);
            this.ClearButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClearButtonContainer.Location = new System.Drawing.Point(602, 0);
            this.ClearButtonContainer.Name = "ClearButtonContainer";
            this.ClearButtonContainer.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.ClearButtonContainer.Size = new System.Drawing.Size(200, 46);
            this.ClearButtonContainer.TabIndex = 5;
            // 
            // ClearButton
            // 
            this.ClearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearButton.Location = new System.Drawing.Point(0, 0);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(195, 46);
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // HideLogButtonContainer
            // 
            this.HideLogButtonContainer.Controls.Add(this.HideLogButton);
            this.HideLogButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.HideLogButtonContainer.Location = new System.Drawing.Point(402, 0);
            this.HideLogButtonContainer.Name = "HideLogButtonContainer";
            this.HideLogButtonContainer.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.HideLogButtonContainer.Size = new System.Drawing.Size(200, 46);
            this.HideLogButtonContainer.TabIndex = 4;
            // 
            // HideLogButton
            // 
            this.HideLogButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HideLogButton.Location = new System.Drawing.Point(0, 0);
            this.HideLogButton.Name = "HideLogButton";
            this.HideLogButton.Size = new System.Drawing.Size(195, 46);
            this.HideLogButton.TabIndex = 0;
            this.HideLogButton.Text = "Hide Log";
            this.HideLogButton.UseVisualStyleBackColor = true;
            this.HideLogButton.Click += new System.EventHandler(this.HideLogButton_Click);
            // 
            // AddFileButtonContainer
            // 
            this.AddFileButtonContainer.Controls.Add(this.AddFileButton);
            this.AddFileButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddFileButtonContainer.Location = new System.Drawing.Point(202, 0);
            this.AddFileButtonContainer.Name = "AddFileButtonContainer";
            this.AddFileButtonContainer.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.AddFileButtonContainer.Size = new System.Drawing.Size(200, 46);
            this.AddFileButtonContainer.TabIndex = 3;
            // 
            // AddFileButton
            // 
            this.AddFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddFileButton.Location = new System.Drawing.Point(0, 0);
            this.AddFileButton.Name = "AddFileButton";
            this.AddFileButton.Size = new System.Drawing.Size(195, 46);
            this.AddFileButton.TabIndex = 0;
            this.AddFileButton.Text = "Add File";
            this.AddFileButton.UseVisualStyleBackColor = true;
            this.AddFileButton.Click += new System.EventHandler(this.AddFileButton_Click);
            // 
            // AddDirectoryButtonContainer
            // 
            this.AddDirectoryButtonContainer.Controls.Add(this.AddDirectoryButton);
            this.AddDirectoryButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddDirectoryButtonContainer.Location = new System.Drawing.Point(5, 0);
            this.AddDirectoryButtonContainer.Name = "AddDirectoryButtonContainer";
            this.AddDirectoryButtonContainer.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.AddDirectoryButtonContainer.Size = new System.Drawing.Size(197, 46);
            this.AddDirectoryButtonContainer.TabIndex = 0;
            // 
            // AddDirectoryButton
            // 
            this.AddDirectoryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddDirectoryButton.Location = new System.Drawing.Point(0, 0);
            this.AddDirectoryButton.Name = "AddDirectoryButton";
            this.AddDirectoryButton.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.AddDirectoryButton.Size = new System.Drawing.Size(192, 46);
            this.AddDirectoryButton.TabIndex = 2;
            this.AddDirectoryButton.Text = "Add Directory";
            this.AddDirectoryButton.UseVisualStyleBackColor = true;
            this.AddDirectoryButton.Click += new System.EventHandler(this.AddDirectoryButton_Click);
            // 
            // TagLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 690);
            this.Controls.Add(this.ButtonsContainer);
            this.Controls.Add(this.ItemsToProcessQueueContainer);
            this.Controls.Add(this.SupportedSitesContainer);
            this.Controls.Add(this.LogContainer);
            this.Name = "TagLookup";
            this.Text = "TagLookup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TagLookup_FormClosing);
            this.Load += new System.EventHandler(this.TagLookup_Load);
            this.SupportedSitesContainer.ResumeLayout(false);
            this.WebsiteButtonsContainer.ResumeLayout(false);
            this.AlbumCoverContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlbumCover)).EndInit();
            this.ItemsToProcessQueueContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemsToProcessQueue)).EndInit();
            this.LogContainer.ResumeLayout(false);
            this.LogContainer.PerformLayout();
            this.ButtonsContainer.ResumeLayout(false);
            this.RunButtonContainer.ResumeLayout(false);
            this.ClearButtonContainer.ResumeLayout(false);
            this.HideLogButtonContainer.ResumeLayout(false);
            this.AddFileButtonContainer.ResumeLayout(false);
            this.AddDirectoryButtonContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SupportedSitesContainer;
        private System.Windows.Forms.CheckedListBox SupportedSites;
        private System.Windows.Forms.Panel ItemsToProcessQueueContainer;
        private System.Windows.Forms.DataGridView ItemsToProcessQueue;
        private System.Windows.Forms.Panel LogContainer;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Panel ButtonsContainer;
        private System.Windows.Forms.Panel AddDirectoryButtonContainer;
        private System.Windows.Forms.Panel AddFileButtonContainer;
        private System.Windows.Forms.Button AddDirectoryButton;
        private System.Windows.Forms.Button AddFileButton;
        private System.Windows.Forms.Panel HideLogButtonContainer;
        private System.Windows.Forms.Button HideLogButton;
        private System.Windows.Forms.Panel ClearButtonContainer;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Panel RunButtonContainer;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Panel AlbumCoverContainer;
        private System.Windows.Forms.PictureBox AlbumCover;
        private System.Windows.Forms.Panel WebsiteButtonsContainer;
        private System.Windows.Forms.Button RemoveWebsiteButton;
        private System.Windows.Forms.Button AddWebsiteButton;
    }
}

