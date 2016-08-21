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
			this.mailboxTextbox = new System.Windows.Forms.TextBox();
			this.addNewEmailButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.serverCombobox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// addressTextbox
			// 
			this.addressTextbox.Location = new System.Drawing.Point(84, 16);
			this.addressTextbox.Name = "addressTextbox";
			this.addressTextbox.Size = new System.Drawing.Size(153, 20);
			this.addressTextbox.TabIndex = 0;
			// 
			// passwordTextbox
			// 
			this.passwordTextbox.Location = new System.Drawing.Point(84, 42);
			this.passwordTextbox.Name = "passwordTextbox";
			this.passwordTextbox.PasswordChar = '*';
			this.passwordTextbox.Size = new System.Drawing.Size(153, 20);
			this.passwordTextbox.TabIndex = 1;
			// 
			// mailboxTextbox
			// 
			this.mailboxTextbox.Location = new System.Drawing.Point(84, 94);
			this.mailboxTextbox.Name = "mailboxTextbox";
			this.mailboxTextbox.Size = new System.Drawing.Size(153, 20);
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Email Address:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(37, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Server:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(32, 98);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Mailbox:";
			// 
			// serverCombobox
			// 
			this.serverCombobox.BackColor = System.Drawing.Color.White;
			this.serverCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.serverCombobox.FormattingEnabled = true;
			this.serverCombobox.Items.AddRange(new object[] {
            "imap.gmail.com",
            "outlook.office365.com"});
			this.serverCombobox.Location = new System.Drawing.Point(83, 67);
			this.serverCombobox.Name = "serverCombobox";
			this.serverCombobox.Size = new System.Drawing.Size(153, 21);
			this.serverCombobox.TabIndex = 9;
			// 
			// AddNewEmailForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(248, 163);
			this.Controls.Add(this.serverCombobox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.addNewEmailButton);
			this.Controls.Add(this.mailboxTextbox);
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
		private System.Windows.Forms.TextBox mailboxTextbox;
		private System.Windows.Forms.Button addNewEmailButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox serverCombobox;
	}
}