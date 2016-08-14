namespace Email_Application {
	partial class AddNewEmailForm {
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
			this.addressTextbox = new System.Windows.Forms.TextBox();
			this.passwordTextbox = new System.Windows.Forms.TextBox();
			this.serverTextbox = new System.Windows.Forms.TextBox();
			this.mailboxTextbox = new System.Windows.Forms.TextBox();
			this.addNewEmailButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// addressTextbox
			// 
			this.addressTextbox.Location = new System.Drawing.Point(12, 16);
			this.addressTextbox.Name = "addressTextbox";
			this.addressTextbox.Size = new System.Drawing.Size(225, 20);
			this.addressTextbox.TabIndex = 0;
			// 
			// passwordTextbox
			// 
			this.passwordTextbox.Location = new System.Drawing.Point(12, 42);
			this.passwordTextbox.Name = "passwordTextbox";
			this.passwordTextbox.PasswordChar = '*';
			this.passwordTextbox.Size = new System.Drawing.Size(225, 20);
			this.passwordTextbox.TabIndex = 1;
			// 
			// serverTextbox
			// 
			this.serverTextbox.Location = new System.Drawing.Point(12, 68);
			this.serverTextbox.Name = "serverTextbox";
			this.serverTextbox.Size = new System.Drawing.Size(225, 20);
			this.serverTextbox.TabIndex = 2;
			// 
			// mailboxTextbox
			// 
			this.mailboxTextbox.Location = new System.Drawing.Point(12, 94);
			this.mailboxTextbox.Name = "mailboxTextbox";
			this.mailboxTextbox.Size = new System.Drawing.Size(225, 20);
			this.mailboxTextbox.TabIndex = 3;
			// 
			// addNewEmailButton
			// 
			this.addNewEmailButton.Location = new System.Drawing.Point(162, 128);
			this.addNewEmailButton.Name = "addNewEmailButton";
			this.addNewEmailButton.Size = new System.Drawing.Size(75, 23);
			this.addNewEmailButton.TabIndex = 4;
			this.addNewEmailButton.Text = "Add";
			this.addNewEmailButton.UseVisualStyleBackColor = true;
			this.addNewEmailButton.Click += new System.EventHandler(this.addNewEmailButton_Click);
			// 
			// AddNewEmailForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(248, 163);
			this.Controls.Add(this.addNewEmailButton);
			this.Controls.Add(this.mailboxTextbox);
			this.Controls.Add(this.serverTextbox);
			this.Controls.Add(this.passwordTextbox);
			this.Controls.Add(this.addressTextbox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddNewEmailForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "New Email";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox addressTextbox;
		private System.Windows.Forms.TextBox passwordTextbox;
		private System.Windows.Forms.TextBox serverTextbox;
		private System.Windows.Forms.TextBox mailboxTextbox;
		private System.Windows.Forms.Button addNewEmailButton;
	}
}