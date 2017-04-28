namespace TagLookup
{
    partial class Mp3FileDialogue
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
            this.TagsContainer = new System.Windows.Forms.Panel();
            this.TagsGrid = new System.Windows.Forms.DataGridView();
            this.ButtonsContainer = new System.Windows.Forms.Panel();
            this.ResetToDefaultTagsButtonContainer = new System.Windows.Forms.Panel();
            this.ResetToDefaultTagsButton = new System.Windows.Forms.Button();
            this.ResetButtonContainer = new System.Windows.Forms.Panel();
            this.ResetToOldTagsButton = new System.Windows.Forms.Button();
            this.SaveCurrentTagsAsDefaultButtonContainer = new System.Windows.Forms.Panel();
            this.SaveCurrentAsDefaultsButton = new System.Windows.Forms.Button();
            this.CopyButtonContainer = new System.Windows.Forms.Panel();
            this.SaveChangesButton = new System.Windows.Forms.Button();
            this.RemoveTagButtonContainer = new System.Windows.Forms.Panel();
            this.RemoveTagButton = new System.Windows.Forms.Button();
            this.AddTagButtonContainer = new System.Windows.Forms.Panel();
            this.AddTagButton = new System.Windows.Forms.Button();
            this.TagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagValueOld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagValueNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Mp3FilePropertiesContainer = new System.Windows.Forms.Panel();
            Mp3FilePropertiesContainer.SuspendLayout();
            this.TagsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TagsGrid)).BeginInit();
            this.ButtonsContainer.SuspendLayout();
            this.ResetToDefaultTagsButtonContainer.SuspendLayout();
            this.ResetButtonContainer.SuspendLayout();
            this.SaveCurrentTagsAsDefaultButtonContainer.SuspendLayout();
            this.CopyButtonContainer.SuspendLayout();
            this.RemoveTagButtonContainer.SuspendLayout();
            this.AddTagButtonContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mp3FilePropertiesContainer
            // 
            Mp3FilePropertiesContainer.Controls.Add(this.TagsContainer);
            Mp3FilePropertiesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            Mp3FilePropertiesContainer.Location = new System.Drawing.Point(0, 0);
            Mp3FilePropertiesContainer.Name = "Mp3FilePropertiesContainer";
            Mp3FilePropertiesContainer.Size = new System.Drawing.Size(1130, 581);
            Mp3FilePropertiesContainer.TabIndex = 1;
            // 
            // TagsContainer
            // 
            this.TagsContainer.Controls.Add(this.TagsGrid);
            this.TagsContainer.Controls.Add(this.ButtonsContainer);
            this.TagsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagsContainer.Location = new System.Drawing.Point(0, 0);
            this.TagsContainer.Name = "TagsContainer";
            this.TagsContainer.Size = new System.Drawing.Size(1130, 581);
            this.TagsContainer.TabIndex = 0;
            // 
            // TagsGrid
            // 
            this.TagsGrid.AllowUserToAddRows = false;
            this.TagsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TagsGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.TagsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TagsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TagName,
            this.TagValueOld,
            this.TagValueNew});
            this.TagsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagsGrid.Location = new System.Drawing.Point(0, 0);
            this.TagsGrid.Name = "TagsGrid";
            this.TagsGrid.RowTemplate.Height = 24;
            this.TagsGrid.Size = new System.Drawing.Size(1130, 518);
            this.TagsGrid.TabIndex = 2;
            // 
            // ButtonsContainer
            // 
            this.ButtonsContainer.Controls.Add(this.ResetToDefaultTagsButtonContainer);
            this.ButtonsContainer.Controls.Add(this.ResetButtonContainer);
            this.ButtonsContainer.Controls.Add(this.SaveCurrentTagsAsDefaultButtonContainer);
            this.ButtonsContainer.Controls.Add(this.CopyButtonContainer);
            this.ButtonsContainer.Controls.Add(this.RemoveTagButtonContainer);
            this.ButtonsContainer.Controls.Add(this.AddTagButtonContainer);
            this.ButtonsContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsContainer.Location = new System.Drawing.Point(0, 518);
            this.ButtonsContainer.Name = "ButtonsContainer";
            this.ButtonsContainer.Size = new System.Drawing.Size(1130, 63);
            this.ButtonsContainer.TabIndex = 1;
            // 
            // ResetToDefaultTagsButtonContainer
            // 
            this.ResetToDefaultTagsButtonContainer.Controls.Add(this.ResetToDefaultTagsButton);
            this.ResetToDefaultTagsButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResetToDefaultTagsButtonContainer.Location = new System.Drawing.Point(752, 0);
            this.ResetToDefaultTagsButtonContainer.Name = "ResetToDefaultTagsButtonContainer";
            this.ResetToDefaultTagsButtonContainer.Padding = new System.Windows.Forms.Padding(3);
            this.ResetToDefaultTagsButtonContainer.Size = new System.Drawing.Size(188, 63);
            this.ResetToDefaultTagsButtonContainer.TabIndex = 12;
            // 
            // ResetToDefaultTagsButton
            // 
            this.ResetToDefaultTagsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResetToDefaultTagsButton.Location = new System.Drawing.Point(3, 3);
            this.ResetToDefaultTagsButton.Name = "ResetToDefaultTagsButton";
            this.ResetToDefaultTagsButton.Size = new System.Drawing.Size(182, 57);
            this.ResetToDefaultTagsButton.TabIndex = 0;
            this.ResetToDefaultTagsButton.Text = "Reset To Default Tags";
            this.ResetToDefaultTagsButton.UseVisualStyleBackColor = true;
            this.ResetToDefaultTagsButton.Click += new System.EventHandler(this.ResetToDefaultTagsButton_Click);
            // 
            // ResetButtonContainer
            // 
            this.ResetButtonContainer.Controls.Add(this.ResetToOldTagsButton);
            this.ResetButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResetButtonContainer.Location = new System.Drawing.Point(564, 0);
            this.ResetButtonContainer.Name = "ResetButtonContainer";
            this.ResetButtonContainer.Padding = new System.Windows.Forms.Padding(3);
            this.ResetButtonContainer.Size = new System.Drawing.Size(188, 63);
            this.ResetButtonContainer.TabIndex = 10;
            // 
            // ResetToOldTagsButton
            // 
            this.ResetToOldTagsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResetToOldTagsButton.Location = new System.Drawing.Point(3, 3);
            this.ResetToOldTagsButton.Name = "ResetToOldTagsButton";
            this.ResetToOldTagsButton.Size = new System.Drawing.Size(182, 57);
            this.ResetToOldTagsButton.TabIndex = 0;
            this.ResetToOldTagsButton.Text = "Reset To Old Tags";
            this.ResetToOldTagsButton.UseVisualStyleBackColor = true;
            this.ResetToOldTagsButton.Click += new System.EventHandler(this.ResetToOldTagsButton_Click);
            // 
            // SaveCurrentTagsAsDefaultButtonContainer
            // 
            this.SaveCurrentTagsAsDefaultButtonContainer.Controls.Add(this.SaveCurrentAsDefaultsButton);
            this.SaveCurrentTagsAsDefaultButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.SaveCurrentTagsAsDefaultButtonContainer.Location = new System.Drawing.Point(376, 0);
            this.SaveCurrentTagsAsDefaultButtonContainer.Name = "SaveCurrentTagsAsDefaultButtonContainer";
            this.SaveCurrentTagsAsDefaultButtonContainer.Padding = new System.Windows.Forms.Padding(3);
            this.SaveCurrentTagsAsDefaultButtonContainer.Size = new System.Drawing.Size(188, 63);
            this.SaveCurrentTagsAsDefaultButtonContainer.TabIndex = 8;
            // 
            // SaveCurrentAsDefaultsButton
            // 
            this.SaveCurrentAsDefaultsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveCurrentAsDefaultsButton.Location = new System.Drawing.Point(3, 3);
            this.SaveCurrentAsDefaultsButton.Name = "SaveCurrentAsDefaultsButton";
            this.SaveCurrentAsDefaultsButton.Size = new System.Drawing.Size(182, 57);
            this.SaveCurrentAsDefaultsButton.TabIndex = 0;
            this.SaveCurrentAsDefaultsButton.Text = "Save Current Tags As Default";
            this.SaveCurrentAsDefaultsButton.UseVisualStyleBackColor = true;
            this.SaveCurrentAsDefaultsButton.Click += new System.EventHandler(this.SaveCurrentAsDefaultsButton_Click);
            // 
            // CopyButtonContainer
            // 
            this.CopyButtonContainer.Controls.Add(this.SaveChangesButton);
            this.CopyButtonContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.CopyButtonContainer.Location = new System.Drawing.Point(942, 0);
            this.CopyButtonContainer.Name = "CopyButtonContainer";
            this.CopyButtonContainer.Padding = new System.Windows.Forms.Padding(3);
            this.CopyButtonContainer.Size = new System.Drawing.Size(188, 63);
            this.CopyButtonContainer.TabIndex = 7;
            // 
            // SaveChangesButton
            // 
            this.SaveChangesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveChangesButton.Location = new System.Drawing.Point(3, 3);
            this.SaveChangesButton.Name = "SaveChangesButton";
            this.SaveChangesButton.Size = new System.Drawing.Size(182, 57);
            this.SaveChangesButton.TabIndex = 0;
            this.SaveChangesButton.Text = "Save Changes";
            this.SaveChangesButton.UseVisualStyleBackColor = true;
            this.SaveChangesButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // RemoveTagButtonContainer
            // 
            this.RemoveTagButtonContainer.Controls.Add(this.RemoveTagButton);
            this.RemoveTagButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.RemoveTagButtonContainer.Location = new System.Drawing.Point(188, 0);
            this.RemoveTagButtonContainer.Name = "RemoveTagButtonContainer";
            this.RemoveTagButtonContainer.Padding = new System.Windows.Forms.Padding(3);
            this.RemoveTagButtonContainer.Size = new System.Drawing.Size(188, 63);
            this.RemoveTagButtonContainer.TabIndex = 11;
            // 
            // RemoveTagButton
            // 
            this.RemoveTagButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveTagButton.Location = new System.Drawing.Point(3, 3);
            this.RemoveTagButton.Name = "RemoveTagButton";
            this.RemoveTagButton.Size = new System.Drawing.Size(182, 57);
            this.RemoveTagButton.TabIndex = 0;
            this.RemoveTagButton.Text = "Remove Tag";
            this.RemoveTagButton.UseVisualStyleBackColor = true;
            this.RemoveTagButton.Click += new System.EventHandler(this.RemoveTagButton_Click);
            // 
            // AddTagButtonContainer
            // 
            this.AddTagButtonContainer.Controls.Add(this.AddTagButton);
            this.AddTagButtonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddTagButtonContainer.Location = new System.Drawing.Point(0, 0);
            this.AddTagButtonContainer.Name = "AddTagButtonContainer";
            this.AddTagButtonContainer.Padding = new System.Windows.Forms.Padding(3);
            this.AddTagButtonContainer.Size = new System.Drawing.Size(188, 63);
            this.AddTagButtonContainer.TabIndex = 9;
            // 
            // AddTagButton
            // 
            this.AddTagButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddTagButton.Location = new System.Drawing.Point(3, 3);
            this.AddTagButton.Name = "AddTagButton";
            this.AddTagButton.Size = new System.Drawing.Size(182, 57);
            this.AddTagButton.TabIndex = 0;
            this.AddTagButton.Text = "Add Tag";
            this.AddTagButton.UseVisualStyleBackColor = true;
            this.AddTagButton.Click += new System.EventHandler(this.AddTagButton_Click);
            // 
            // TagName
            // 
            this.TagName.DataPropertyName = "tagName";
            this.TagName.HeaderText = "Tag Name";
            this.TagName.Name = "TagName";
            this.TagName.ReadOnly = true;
            // 
            // TagValueOld
            // 
            this.TagValueOld.DataPropertyName = "tagValueOld";
            this.TagValueOld.HeaderText = "Current Tag Value";
            this.TagValueOld.Name = "TagValueOld";
            this.TagValueOld.ReadOnly = true;
            // 
            // TagValueNew
            // 
            this.TagValueNew.DataPropertyName = "tagValuenew";
            this.TagValueNew.HeaderText = "New Tag Value";
            this.TagValueNew.Name = "TagValueNew";
            // 
            // Mp3FileDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 581);
            this.Controls.Add(Mp3FilePropertiesContainer);
            this.Name = "Mp3FileDialogue";
            this.Text = "Mp3FileDialogue";
            Mp3FilePropertiesContainer.ResumeLayout(false);
            this.TagsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TagsGrid)).EndInit();
            this.ButtonsContainer.ResumeLayout(false);
            this.ResetToDefaultTagsButtonContainer.ResumeLayout(false);
            this.ResetButtonContainer.ResumeLayout(false);
            this.SaveCurrentTagsAsDefaultButtonContainer.ResumeLayout(false);
            this.CopyButtonContainer.ResumeLayout(false);
            this.RemoveTagButtonContainer.ResumeLayout(false);
            this.AddTagButtonContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel TagsContainer;
        private System.Windows.Forms.Panel ButtonsContainer;
        private System.Windows.Forms.Panel CopyButtonContainer;
        private System.Windows.Forms.Button SaveChangesButton;
        private System.Windows.Forms.Panel ResetButtonContainer;
        private System.Windows.Forms.Button ResetToOldTagsButton;
        private System.Windows.Forms.Panel AddTagButtonContainer;
        private System.Windows.Forms.Button AddTagButton;
        private System.Windows.Forms.Panel SaveCurrentTagsAsDefaultButtonContainer;
        private System.Windows.Forms.Button SaveCurrentAsDefaultsButton;
        private System.Windows.Forms.DataGridView TagsGrid;
        private System.Windows.Forms.Panel RemoveTagButtonContainer;
        private System.Windows.Forms.Button RemoveTagButton;
        private System.Windows.Forms.Panel ResetToDefaultTagsButtonContainer;
        private System.Windows.Forms.Button ResetToDefaultTagsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagValueOld;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagValueNew;
    }
}