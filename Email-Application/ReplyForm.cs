using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Email_Application {
	public partial class ReplyForm : Form {
		string username, message;

		public ReplyForm() {
			InitializeComponent();
		}

		public ReplyForm(string username, string message, string from) {
			InitializeComponent();
			this.username = username;
			this.message = message;

			replyBox.Text = message;
			if(from.IndexOf("From: ") != -1) {
				from.Substring(5);
			}
			replyToBox.Text = from;
		}

		private void sendButton_Click(object sender, EventArgs e) {
			var mail = new Mail();
			var re = new Regex( @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
			var valid = re.IsMatch(replyToBox.Text);

			if(valid) {
				mail.sendMail("Fixed subject", replyBox.Text, replyToBox.Text, username);
				Thread.Sleep(2000);
				this.Close();
			} else {
				MessageBox.Show("Invalid email address entered!");
			}

		}
	}
}
