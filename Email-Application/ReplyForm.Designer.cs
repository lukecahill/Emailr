namespace Email_Application {
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
			this.replyBox = new System.Windows.Forms.RichTextBox();
			this.replyToBox = new System.Windows.Forms.RichTextBox();
			this.sendButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// replyBox
			// 
			this.replyBox.Location = new System.Drawing.Point(12, 75);
			this.replyBox.Name = "replyBox";
			this.replyBox.Size = new System.Drawing.Size(696, 353);
			this.replyBox.TabIndex = 0;
			this.replyBox.Text = "";
			// 
			// replyToBox
			// 
			this.replyToBox.Location = new System.Drawing.Point(12, 12);
			this.replyToBox.Name = "replyToBox";
			this.replyToBox.Size = new System.Drawing.Size(696, 21);
			this.replyToBox.TabIndex = 1;
			this.replyToBox.Text = "";
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
			// ReplyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 483);
			this.Controls.Add(this.sendButton);
			this.Controls.Add(this.replyToBox);
			this.Controls.Add(this.replyBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.Name = "ReplyForm";
			this.Text = "ReplyForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox replyBox;
		private System.Windows.Forms.RichTextBox replyToBox;
		private System.Windows.Forms.Button sendButton;
	}
}