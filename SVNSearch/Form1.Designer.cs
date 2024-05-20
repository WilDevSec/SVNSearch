namespace SVNSearch
{
    partial class SVNSearch
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            searchBox = new TextBox();
            searchButton = new Button();
            urlBox = new TextBox();
            searchTextLabel = new Label();
            URLLabel = new Label();
            SlowInfoLabel = new Label();
            outputPanel = new FlowLayoutPanel();
            searchOutput = new TextBox();
            SuspendLayout();
            // 
            // searchBox
            // 
            searchBox.AccessibleName = "";
            searchBox.AccessibleRole = AccessibleRole.MenuBar;
            searchBox.Location = new Point(34, 62);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(302, 23);
            searchBox.TabIndex = 0;
            searchBox.KeyDown += searchBox_KeyDown;
            // 
            // searchButton
            // 
            searchButton.BackColor = SystemColors.ButtonFace;
            searchButton.Location = new Point(370, 55);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(105, 34);
            searchButton.TabIndex = 2;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += button1_Click;
            // 
            // urlBox
            // 
            urlBox.Location = new Point(34, 106);
            urlBox.Name = "urlBox";
            urlBox.PlaceholderText = "Copy from Tortoise SVN (top of the repo browser)  e.g. file:///torr-svn/Database/Projects/ etc.";
            urlBox.RightToLeft = RightToLeft.No;
            urlBox.ScrollBars = ScrollBars.Vertical;
            urlBox.Size = new Size(832, 23);
            urlBox.TabIndex = 4;
            urlBox.KeyDown += urlBox_KeyDown;
            // 
            // searchTextLabel
            // 
            searchTextLabel.AutoSize = true;
            searchTextLabel.Location = new Point(34, 44);
            searchTextLabel.Name = "searchTextLabel";
            searchTextLabel.Size = new Size(66, 15);
            searchTextLabel.TabIndex = 5;
            searchTextLabel.Text = "Search Text";
            // 
            // URLLabel
            // 
            URLLabel.AutoSize = true;
            URLLabel.Location = new Point(34, 88);
            URLLabel.Name = "URLLabel";
            URLLabel.Size = new Size(28, 15);
            URLLabel.TabIndex = 6;
            URLLabel.Text = "URL";
            // 
            // SlowInfoLabel
            // 
            SlowInfoLabel.AutoSize = true;
            SlowInfoLabel.Location = new Point(34, 476);
            SlowInfoLabel.Name = "SlowInfoLabel";
            SlowInfoLabel.Size = new Size(408, 15);
            SlowInfoLabel.TabIndex = 7;
            SlowInfoLabel.Text = "This search can be very slow; try searching specific folders for quicker results";
            // 
            // outputPanel
            // 
            outputPanel.FlowDirection = FlowDirection.TopDown;
            outputPanel.Location = new Point(34, 146);
            outputPanel.Name = "outputPanel";
            outputPanel.Size = new Size(832, 232);
            outputPanel.TabIndex = 8;
            // 
            // searchOutput
            // 
            searchOutput.Location = new Point(34, 394);
            searchOutput.Multiline = true;
            searchOutput.Name = "searchOutput";
            searchOutput.ReadOnly = true;
            searchOutput.Size = new Size(832, 64);
            searchOutput.TabIndex = 3;
            searchOutput.TextChanged += searchOutput_TextChanged;
            // 
            // SVNSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 552);
            Controls.Add(outputPanel);
            Controls.Add(SlowInfoLabel);
            Controls.Add(URLLabel);
            Controls.Add(searchTextLabel);
            Controls.Add(urlBox);
            Controls.Add(searchOutput);
            Controls.Add(searchButton);
            Controls.Add(searchBox);
            Name = "SVNSearch";
            Text = "SVN Search";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchBox;
        private Button searchButton;
        private TextBox urlBox;
        private Label searchTextLabel;
        private Label URLLabel;
        private Label SlowInfoLabel;
        private FlowLayoutPanel outputPanel;
        private TextBox searchOutput;
    }
}