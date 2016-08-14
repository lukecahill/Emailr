namespace Email_Application {
	partial class emailrForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fetchNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.subjectBox = new System.Windows.Forms.RichTextBox();
			this.fetchNewMailButton = new System.Windows.Forms.Button();
			this.emailList = new System.Windows.Forms.ListBox();
			this.emailListCountLabel = new System.Windows.Forms.Label();
			this.replyButton = new System.Windows.Forms.Button();
			this.fromLabel = new System.Windows.Forms.Label();
			this.searchTextBox = new System.Windows.Forms.TextBox();
			this.searchEmailButton = new System.Windows.Forms.Button();
			this.messageBox = new System.Windows.Forms.WebBrowser();
			this.newEmailButton = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mailToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(688, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// mailToolStripMenuItem
			// 
			this.mailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fetchNewToolStripMenuItem});
			this.mailToolStripMenuItem.Name = "mailToolStripMenuItem";
			this.mailToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
			this.mailToolStripMenuItem.Text = "&Mail";
			// 
			// fetchNewToolStripMenuItem
			// 
			this.fetchNewToolStripMenuItem.Name = "fetchNewToolStripMenuItem";
			this.fetchNewToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.fetchNewToolStripMenuItem.Text = "&Fetch new";
			this.fetchNewToolStripMenuItem.Click += new System.EventHandler(this.fetchNewToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 558);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(688, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// progressBar
			// 
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(150, 16);
			this.progressBar.Step = 1;
			// 
			// subjectBox
			// 
			this.subjectBox.BackColor = System.Drawing.Color.White;
			this.subjectBox.Location = new System.Drawing.Point(270, 77);
			this.subjectBox.Name = "subjectBox";
			this.subjectBox.ReadOnly = true;
			this.subjectBox.Size = new System.Drawing.Size(407, 32);
			this.subjectBox.TabIndex = 4;
			this.subjectBox.Text = "";
			// 
			// fetchNewMailButton
			// 
			this.fetchNewMailButton.Location = new System.Drawing.Point(550, 27);
			this.fetchNewMailButton.Name = "fetchNewMailButton";
			this.fetchNewMailButton.Size = new System.Drawing.Size(126, 44);
			this.fetchNewMailButton.TabIndex = 5;
			this.fetchNewMailButton.Text = "Fetch New Mail";
			this.fetchNewMailButton.UseVisualStyleBackColor = true;
			this.fetchNewMailButton.Click += new System.EventHandler(this.fetchNewMailButton_Click);
			// 
			// emailList
			// 
			this.emailList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.emailList.FormattingEnabled = true;
			this.emailList.Location = new System.Drawing.Point(12, 77);
			this.emailList.Name = "emailList";
			this.emailList.Size = new System.Drawing.Size(252, 472);
			this.emailList.TabIndex = 6;
			this.emailList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.emailList_MouseDoubleClick);
			this.emailList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.emailList_MouseUp);
			// 
			// emailListCountLabel
			// 
			this.emailListCountLabel.AutoSize = true;
			this.emailListCountLabel.Location = new System.Drawing.Point(12, 27);
			this.emailListCountLabel.Name = "emailListCountLabel";
			this.emailListCountLabel.Size = new System.Drawing.Size(0, 13);
			this.emailListCountLabel.TabIndex = 7;
			// 
			// replyButton
			// 
			this.replyButton.Location = new System.Drawing.Point(442, 27);
			this.replyButton.Name = "replyButton";
			this.replyButton.Size = new System.Drawing.Size(102, 44);
			this.replyButton.TabIndex = 8;
			this.replyButton.Text = "Reply";
			this.replyButton.UseVisualStyleBackColor = true;
			this.replyButton.Click += new System.EventHandler(this.replyButton_Click);
			// 
			// fromLabel
			// 
			this.fromLabel.AutoSize = true;
			this.fromLabel.Location = new System.Drawing.Point(278, 58);
			this.fromLabel.Name = "fromLabel";
			this.fromLabel.Size = new System.Drawing.Size(0, 13);
			this.fromLabel.TabIndex = 9;
			// 
			// searchTextBox
			// 
			this.searchTextBox.Location = new System.Drawing.Point(12, 51);
			this.searchTextBox.Name = "searchTextBox";
			this.searchTextBox.Size = new System.Drawing.Size(219, 20);
			this.searchTextBox.TabIndex = 10;
			this.searchTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyUp);
			// 
			// searchEmailButton
			// 
			this.searchEmailButton.Location = new System.Drawing.Point(237, 51);
			this.searchEmailButton.Name = "searchEmailButton";
			this.searchEmailButton.Size = new System.Drawing.Size(27, 20);
			this.searchEmailButton.TabIndex = 11;
			this.searchEmailButton.Text = "S";
			this.searchEmailButton.UseVisualStyleBackColor = true;
			this.searchEmailButton.Click += new System.EventHandler(this.searchEmailButton_Click);
			// 
			// messageBox
			// 
			this.messageBox.AllowWebBrowserDrop = false;
			this.messageBox.Location = new System.Drawing.Point(270, 115);
			this.messageBox.MinimumSize = new System.Drawing.Size(20, 20);
			this.messageBox.Name = "messageBox";
			this.messageBox.Size = new System.Drawing.Size(407, 434);
			this.messageBox.TabIndex = 12;
			this.messageBox.WebBrowserShortcutsEnabled = false;
			// 
			// newEmailButton
			// 
			this.newEmailButton.Location = new System.Drawing.Point(270, 27);
			this.newEmailButton.Name = "newEmailButton";
			this.newEmailButton.Size = new System.Drawing.Size(102, 44);
			this.newEmailButton.TabIndex = 13;
			this.newEmailButton.Text = "New Email";
			this.newEmailButton.UseVisualStyleBackColor = true;
			this.newEmailButton.Click += new System.EventHandler(this.newEmailButton_Click);
			// 
			// emailrForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(688, 580);
			this.Controls.Add(this.newEmailButton);
			this.Controls.Add(this.messageBox);
			this.Controls.Add(this.searchEmailButton);
			this.Controls.Add(this.searchTextBox);
			this.Controls.Add(this.fromLabel);
			this.Controls.Add(this.replyButton);
			this.Controls.Add(this.emailListCountLabel);
			this.Controls.Add(this.emailList);
			this.Controls.Add(this.fetchNewMailButton);
			this.Controls.Add(this.subjectBox);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "emailrForm";
			this.Text = "Emailr";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mailToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fetchNewToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar progressBar;
		private System.Windows.Forms.RichTextBox subjectBox;
		private System.Windows.Forms.Button fetchNewMailButton;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ListBox emailList;
		private System.Windows.Forms.Label emailListCountLabel;
		private System.Windows.Forms.Button replyButton;
		private System.Windows.Forms.Label fromLabel;
		private System.Windows.Forms.TextBox searchTextBox;
		private System.Windows.Forms.Button searchEmailButton;
		private System.Windows.Forms.WebBrowser messageBox;
		private System.Windows.Forms.Button newEmailButton;
	}
}

