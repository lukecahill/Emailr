using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Email_Application {
	public partial class ReplyForm : Form {
		string username, message, subject;

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
	}
}
