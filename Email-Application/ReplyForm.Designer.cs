﻿namespace Email_Application {
	partial class ReplyForm {
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
			this.replyToBox = new System.Windows.Forms.RichTextBox();
			this.sendButton = new System.Windows.Forms.Button();
			this.replyBox = new System.Windows.Forms.RichTextBox();
			this.subjectTextBox = new System.Windows.Forms.RichTextBox();
			this.toLabel = new System.Windows.Forms.Label();
			this.subjectLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// replyToBox
			// 
			this.replyToBox.Location = new System.Drawing.Point(58, 12);
			this.replyToBox.Name = "replyToBox";
			this.replyToBox.Size = new System.Drawing.Size(650, 21);
			this.replyToBox.TabIndex = 1;
			this.replyToBox.Text = "";
			this.replyToBox.TextChanged += new System.EventHandler(this.replyToBox_TextChanged);
			// 
			// sendButton
			// 
			this.sendButton.Location = new System.Drawing.Point(585, 434);
			this.sendButton.Name = "sendButton";
			this.sendButton.Size = new System.Drawing.Size(123, 37);
			this.sendButton.TabIndex = 2;
			this.sendButton.Text = "Send";
			this.sendButton.UseVisualStyleBackColor = true;
			this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
			// 
			// replyBox
			// 
			this.replyBox.Location = new System.Drawing.Point(12, 75);
			this.replyBox.Name = "replyBox";
			this.replyBox.Size = new System.Drawing.Size(696, 353);
			this.replyBox.TabIndex = 0;
			this.replyBox.Text = "";
			this.replyBox.TextChanged += new System.EventHandler(this.replyBox_TextChanged);
			this.replyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.replyBox_KeyDown);
			// 
			// subjectTextBox
			// 
			this.subjectTextBox.Location = new System.Drawing.Point(58, 39);
			this.subjectTextBox.Name = "subjectTextBox";
			this.subjectTextBox.Size = new System.Drawing.Size(650, 30);
			this.subjectTextBox.TabIndex = 3;
			this.subjectTextBox.Text = "";
			this.subjectTextBox.TextChanged += new System.EventHandler(this.subjectTextBox_TextChanged);
			// 
			// toLabel
			// 
			this.toLabel.AutoSize = true;
			this.toLabel.Location = new System.Drawing.Point(29, 12);
			this.toLabel.Name = "toLabel";
			this.toLabel.Size = new System.Drawing.Size(23, 13);
			this.toLabel.TabIndex = 4;
			this.toLabel.Text = "To:";
			// 
			// subjectLabel
			// 
			this.subjectLabel.AutoSize = true;
			this.subjectLabel.Location = new System.Drawing.Point(9, 42);
			this.subjectLabel.Name = "subjectLabel";
			this.subjectLabel.Size = new System.Drawing.Size(46, 13);
			this.subjectLabel.TabIndex = 5;
			this.subjectLabel.Text = "Subject:";
			// 
			// ReplyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 483);
			this.Controls.Add(this.subjectLabel);
			this.Controls.Add(this.toLabel);
			this.Controls.Add(this.subjectTextBox);
			this.Controls.Add(this.sendButton);
			this.Controls.Add(this.replyToBox);
			this.Controls.Add(this.replyBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.Name = "ReplyForm";
			this.Text = "ReplyForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.RichTextBox replyToBox;
		private System.Windows.Forms.Button sendButton;
		private System.Windows.Forms.RichTextBox replyBox;
		private System.Windows.Forms.RichTextBox subjectTextBox;
		private System.Windows.Forms.Label toLabel;
		private System.Windows.Forms.Label subjectLabel;
	}
}