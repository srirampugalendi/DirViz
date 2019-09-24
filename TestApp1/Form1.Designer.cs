namespace TestApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resetButton = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.expandOrCollapseButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.matchCase = new System.Windows.Forms.CheckBox();
            this.domainNameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(905, 9);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(136, 23);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Location = new System.Drawing.Point(12, 38);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(1029, 472);
            this.treeView.TabIndex = 1;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(735, 9);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(508, 10);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(221, 20);
            this.searchBox.TabIndex = 3;
            this.searchBox.Text = "Enter Search Text";
            this.searchBox.Click += new System.EventHandler(this.SearchBox_Click);
            // 
            // expandOrCollapseButton
            // 
            this.expandOrCollapseButton.Location = new System.Drawing.Point(390, 8);
            this.expandOrCollapseButton.Name = "expandOrCollapseButton";
            this.expandOrCollapseButton.Size = new System.Drawing.Size(112, 23);
            this.expandOrCollapseButton.TabIndex = 4;
            this.expandOrCollapseButton.Text = "Expand/Collapse All";
            this.expandOrCollapseButton.UseVisualStyleBackColor = true;
            this.expandOrCollapseButton.Click += new System.EventHandler(this.ExpandOrCollapseButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(12, 9);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 5;
            this.openButton.Text = "Open File";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // matchCase
            // 
            this.matchCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.matchCase.AutoSize = true;
            this.matchCase.Location = new System.Drawing.Point(816, 13);
            this.matchCase.Name = "matchCase";
            this.matchCase.Size = new System.Drawing.Size(83, 17);
            this.matchCase.TabIndex = 6;
            this.matchCase.Text = "Match Case";
            this.matchCase.UseVisualStyleBackColor = true;
            // 
            // domainNameBox
            // 
            this.domainNameBox.Location = new System.Drawing.Point(93, 9);
            this.domainNameBox.Name = "domainNameBox";
            this.domainNameBox.Size = new System.Drawing.Size(291, 20);
            this.domainNameBox.TabIndex = 7;
            this.domainNameBox.Text = "Enter Domin Name <http://example.com/>";
            this.domainNameBox.Click += new System.EventHandler(this.DomainNameBox_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1053, 522);
            this.Controls.Add(this.domainNameBox);
            this.Controls.Add(this.matchCase);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.expandOrCollapseButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.resetButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(1069, 561);
            this.Name = "Form1";
            this.Text = "DirectoryVizualizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button expandOrCollapseButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.CheckBox matchCase;
        private System.Windows.Forms.TextBox domainNameBox;
    }
}

