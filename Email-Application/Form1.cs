using AE.Net.Mail;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Email_Application {
	public partial class emailrForm : Form {

		FetchMail fetch = null;
		string server = "gmail";
		public emailrForm() {
			InitializeComponent();
			progressBar.Maximum = 100;
			progressBar.Minimum = 0;
			progressBar.Step = 1;
			fetch = new FetchMail();
		}

		private void FetchMessages() {
			using(var client = new ImapClient()) {
				var username = "";
				var password = "";
				var mailbox = "";

				if(server == "gmail") {
					client.Connect("imap.gmail.com", 993, true, true);
					mailbox = "inbox";
				} else if(server == "outlook") {
					client.Connect("outlook.office365.com", 993, true, true);
					mailbox = "Inbox";
				} else if(server == "yahoo") {
					client.Connect("", 993, true, true);
					mailbox = "Inbox";
				}

				client.Login(username, password);
				fetch.GetMessages(client, mailbox, progressBar, richTextBox2, richTextBox1);
			}

		}

		private void fetchNewToolStripMenuItem_Click(object sender, EventArgs e) {
			FetchMessages();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e) {
			var info = new ProcessStartInfo(Application.ExecutablePath);
			Process.Start(info);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Environment.Exit(0);
		}

		private void fetchNewMailButton_Click(object sender, EventArgs e) {
			FetchMessages();
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show("No point looking here for help. IDK what is happening here at the moment...");
		}
	}
}
