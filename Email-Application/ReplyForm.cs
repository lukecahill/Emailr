using System;
using System.Threading;
using System.Windows.Forms;

namespace Email_Application {
	public partial class ReplyForm : Form {
		string username, message;

		public ReplyForm() {
			InitializeComponent();
		}

		public ReplyForm(string username, string message) {
			InitializeComponent();
			this.username = username;
			this.message = message;

			replyBox.Text = message;
		}

		private void sendButton_Click(object sender, EventArgs e) {
			var mail = new Mail();
			mail.sendMail("Fixed subject", replyBox.Text, replyToBox.Text, username);
			Thread.Sleep(2000);
			this.Close();
		}
	}
}
