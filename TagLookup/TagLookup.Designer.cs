namespace TagLookup
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
            this.SupportedSites = new System.Windows.Forms.CheckedListBox();
            this.ItemsToProcessQueueContainer = new System.Windows.Forms.Panel();
            this.ItemsToProcessQueue = new System.Windows.Forms.DataGridView();
            this.LogContainer = new System.Windows.Forms.Panel();
            this.Log = new System.Windows.Forms.TextBox();
            this.ButtonsContainer = new System.Windows.Forms.Panel();
            this.RunButtonContainer = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.ClearButtonContainer = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.HideLogButtonContainer = new System.Windows.Forms.Panel();
            this.HideLogButton = new System.Windows.Forms.Button();
            this.AddFileButtonContainer = new System.Windows.Forms.Panel();
            this.AddFileButton = new System.Windows.Forms.Button();
            this.AddDirectoryButtonContainer = new System.Windows.Forms.Panel();
            this.AddDirectoryButton = new System.Windows.Forms.Button();
            this.SupportedSitesContainer.SuspendLayout();
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
            this.SupportedSitesContainer.Controls.Add(this.SupportedSites);
            this.SupportedSitesContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.SupportedSitesContainer.Location = new System.Drawing.Point(0, 0);
            this.SupportedSitesContainer.Margin = new System.Windows.Forms.Padding(0);
            this.SupportedSitesContainer.MinimumSize = new System.Drawing.Size(151, 538);
            this.SupportedSitesContainer.Name = "SupportedSitesContainer";
            this.SupportedSitesContainer.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.SupportedSitesContainer.Size = new System.Drawing.Size(151, 538);
            this.SupportedSitesContainer.TabIndex = 0;
            // 
            // SupportedSites
            // 
            this.SupportedSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupportedSites.FormattingEnabled = true;
            this.SupportedSites.Location = new System.Drawing.Point(5, 5);
            this.SupportedSites.Name = "SupportedSites";
            this.SupportedSites.Size = new System.Drawing.Size(146, 533);
            this.SupportedSites.TabIndex = 0;
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
            // 
            // LogContainer
            // 
            this.LogContainer.Controls.Add(this.Log);
            this.LogContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogContainer.Location = new System.Drawing.Point(0, 538);
            this.LogContainer.MinimumSize = new System.Drawing.Size(1159, 152);
            this.LogContainer.Name = "LogContainer";
            this.LogContainer.Padding = new System.Windows.Forms.Padding(5);
            this.LogContainer.Size = new System.Drawing.Size(1159, 152);
            this.LogContainer.TabIndex = 1;
            // 
            // Log
            // 
            this.Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log.Location = new System.Drawing.Point(5, 5);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(1149, 142);
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
            this.ButtonsContainer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ButtonsContainer.Size = new System.Drawing.Size(1008, 51);
            this.ButtonsContainer.TabIndex = 1;
            // 
            // RunButtonContainer
            // 
            this.RunButtonContainer.Controls.Add(this.button5);
            this.RunButtonContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunButtonContainer.Location = new System.Drawing.Point(802, 0);
            this.RunButtonContainer.Name = "RunButtonContainer";
            this.RunButtonContainer.Size = new System.Drawing.Size(201, 51);
            this.RunButtonContainer.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Left;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(201, 51);
            this.button5.TabIndex = 0;
            this.button5.Text = "Run";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // ClearButtonContainer
            // 
            this.ClearButtonContainer.Controls.Add(this.button4);
            this.ClearButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClearButtonContainer.Location = new System.Drawing.Point(602, 0);
            this.ClearButtonContainer.Name = "ClearButtonContainer";
            this.ClearButtonContainer.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.ClearButtonContainer.Size = new System.Drawing.Size(200, 51);
            this.ClearButtonContainer.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(195, 51);
            this.button4.TabIndex = 0;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // HideLogButtonContainer
            // 
            this.HideLogButtonContainer.Controls.Add(this.HideLogButton);
            this.HideLogButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.HideLogButtonContainer.Location = new System.Drawing.Point(402, 0);
            this.HideLogButtonContainer.Name = "HideLogButtonContainer";
            this.HideLogButtonContainer.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.HideLogButtonContainer.Size = new System.Drawing.Size(200, 51);
            this.HideLogButtonContainer.TabIndex = 4;
            // 
            // HideLogButton
            // 
            this.HideLogButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HideLogButton.Location = new System.Drawing.Point(0, 0);
            this.HideLogButton.Name = "HideLogButton";
            this.HideLogButton.Size = new System.Drawing.Size(195, 51);
            this.HideLogButton.TabIndex = 0;
            this.HideLogButton.Text = "Hide Log";
            this.HideLogButton.UseVisualStyleBackColor = true;
            // 
            // AddFileButtonContainer
            // 
            this.AddFileButtonContainer.Controls.Add(this.AddFileButton);
            this.AddFileButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddFileButtonContainer.Location = new System.Drawing.Point(202, 0);
            this.AddFileButtonContainer.Name = "AddFileButtonContainer";
            this.AddFileButtonContainer.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.AddFileButtonContainer.Size = new System.Drawing.Size(200, 51);
            this.AddFileButtonContainer.TabIndex = 3;
            // 
            // AddFileButton
            // 
            this.AddFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddFileButton.Location = new System.Drawing.Point(0, 0);
            this.AddFileButton.Name = "AddFileButton";
            this.AddFileButton.Size = new System.Drawing.Size(195, 51);
            this.AddFileButton.TabIndex = 0;
            this.AddFileButton.Text = "Add File";
            this.AddFileButton.UseVisualStyleBackColor = true;
            // 
            // AddDirectoryButtonContainer
            // 
            this.AddDirectoryButtonContainer.Controls.Add(this.AddDirectoryButton);
            this.AddDirectoryButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddDirectoryButtonContainer.Location = new System.Drawing.Point(5, 0);
            this.AddDirectoryButtonContainer.Name = "AddDirectoryButtonContainer";
            this.AddDirectoryButtonContainer.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.AddDirectoryButtonContainer.Size = new System.Drawing.Size(197, 51);
            this.AddDirectoryButtonContainer.TabIndex = 0;
            // 
            // AddDirectoryButton
            // 
            this.AddDirectoryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddDirectoryButton.Location = new System.Drawing.Point(0, 0);
            this.AddDirectoryButton.Name = "AddDirectoryButton";
            this.AddDirectoryButton.Size = new System.Drawing.Size(192, 51);
            this.AddDirectoryButton.TabIndex = 2;
            this.AddDirectoryButton.Text = "Add Directory";
            this.AddDirectoryButton.UseVisualStyleBackColor = true;
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
            this.SupportedSitesContainer.ResumeLayout(false);
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
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel RunButtonContainer;
        private System.Windows.Forms.Button button5;
    }
}

