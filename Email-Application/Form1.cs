using AE.Net.Mail;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Email_Application {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			progressBar.Maximum = 100;
			progressBar.Minimum = 0;
			progressBar.Step = 1;
		}

		private void FetchMessages() {
			using(var client = new ImapClient()) {
				client.Connect("imap.gmail.com", 993, true, true);
				var username = "";
				var password = "";

				client.Login(username, password);
				GetMessages(client);
			}
		}

		private void GetMessages(ImapClient client) {
			if(client.IsConnected) {
				client.SelectMailbox("inbox");
				var messages = GetUnseenMessages(client);
				var count = messages.Count();

				if(count > 0) {
					progressBar.Maximum = count;
					LoopThroughMessages(client, messages, count);
				} else {
					Debug.WriteLine("No new mail has been found.");
				}
			}
		}

		private Lazy<MailMessage>[] GetUnseenMessages(ImapClient client) {
			var messages = client.SearchMessages(SearchCondition.Unseen());
			return messages;
		}

		private void LoopThroughMessages(ImapClient client, Lazy<MailMessage>[] messages, int count) {
			MailMessage[] mailMessage = new MailMessage[count];
			var j = 0;
			foreach (var item in messages) {
				var message = item.Value.Body;
				mailMessage[j] = item.Value;
				richTextBox2.Text = item.Value.Subject;
				richTextBox1.Text = item.Value.Body;
				progressBar.PerformStep();
				j++;

				var i = new Mail {
					MailId = 1,
					MailBody = item.Value.Body,
					MailSubject = item.Value.Subject,
					MailToAddress = item.Value.To,
					MailCCAddresses = item.Value.Cc
				};
			}
			//client.SetFlags(Flags.Seen, mailMessage);
			Debug.WriteLine("Mail has been fetched successfully!");
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
	}
}
