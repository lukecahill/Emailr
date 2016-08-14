using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Email_Application {
	public partial class ReplyForm : Form {
		string username, message, subject;
		private bool saved = false;

		public ReplyForm() {
			InitializeComponent();
		}

		public ReplyForm(string username, string message, string subject, string from) {
			InitializeComponent();
			this.username = username;
			this.message = message;
			this.subject = subject;
			
			if(from.IndexOf("From: ") > -1) {
				from = from.Substring(5);
			}
			replyToBox.Text = from.Trim();
			this.subjectTextBox.Text = $"RE: {subject}";
		}

		private void sendButton_Click(object sender, EventArgs e) {
			var mail = new Mail();
			var re = new Regex( @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
			var valid = re.IsMatch(replyToBox.Text);

			if(valid) {
				mail.sendMail(subjectTextBox.Text, replyBox.Text, replyToBox.Text, username);
				Thread.Sleep(2000);
				this.Close();
			} else {
				MessageBox.Show("Invalid email address entered!");
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e) {
			base.OnFormClosing(e);

			if (e.CloseReason == CloseReason.UserClosing) {
				var isSaved = CheckExit(saved);
				var close = ExitApplication(isSaved);

				e.Cancel = close;
			} else {
				// only want to prompt to save if the user is the close reason. Otherwise
				//      return as seen here e.g. if the computer is shutting down.
				return;
			}
		}

		private void replyBox_TextChanged(object sender, EventArgs e) {
			saved = false;
		}

		private void subjectTextBox_TextChanged(object sender, EventArgs e) {
			saved = false;
		}

		private void replyToBox_TextChanged(object sender, EventArgs e) {
			saved = false;
		}

		private bool ExitApplication(int code) {
			var close = true;
			switch (code) {
				case 0:
					close = false;
					break;
				case 1:
					close = true;
					break;
			}
			return close;
		}

		public int CheckExit(bool saved) {
			if (saved) {
				return 0;
			} else {

				var ok = MessageBox.Show("Are you sure you wish to exit. \nAny changes will be lost.", "Changes made!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

				if (ok == DialogResult.Yes) {
					return 0;
				} else {
					return 1;
				}
			}
		}
	}
}
