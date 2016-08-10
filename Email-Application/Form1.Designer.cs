﻿namespace Email_Application {
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			this.fetchNewMailButton = new System.Windows.Forms.Button();
			this.emailList = new System.Windows.Forms.ListBox();
			this.emailListCountLabel = new System.Windows.Forms.Label();
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
			this.fileToolStripMenuItem.Text = "File";
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
			this.mailToolStripMenuItem.Text = "Mail";
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
			this.helpToolStripMenuItem.Text = "Help";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 558);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(688, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// progressBar
			// 
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(150, 16);
			this.progressBar.Step = 1;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(270, 115);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(407, 434);
			this.richTextBox1.TabIndex = 3;
			this.richTextBox1.Text = "";
			// 
			// richTextBox2
			// 
			this.richTextBox2.Location = new System.Drawing.Point(270, 77);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.Size = new System.Drawing.Size(407, 32);
			this.richTextBox2.TabIndex = 4;
			this.richTextBox2.Text = "";
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
			this.emailList.FormattingEnabled = true;
			this.emailList.Location = new System.Drawing.Point(12, 77);
			this.emailList.Name = "emailList";
			this.emailList.Size = new System.Drawing.Size(252, 472);
			this.emailList.TabIndex = 6;
			// 
			// emailListCountLabel
			// 
			this.emailListCountLabel.AutoSize = true;
			this.emailListCountLabel.Location = new System.Drawing.Point(12, 43);
			this.emailListCountLabel.Name = "emailListCountLabel";
			this.emailListCountLabel.Size = new System.Drawing.Size(0, 13);
			this.emailListCountLabel.TabIndex = 7;
			// 
			// emailrForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(688, 580);
			this.Controls.Add(this.emailListCountLabel);
			this.Controls.Add(this.emailList);
			this.Controls.Add(this.fetchNewMailButton);
			this.Controls.Add(this.richTextBox2);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
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
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.Button fetchNewMailButton;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ListBox emailList;
		private System.Windows.Forms.Label emailListCountLabel;
	}
}

