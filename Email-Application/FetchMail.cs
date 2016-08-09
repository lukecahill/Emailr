using AE.Net.Mail;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Email_Application {
	public class FetchMail {

		public void GetMessages(ImapClient client, string mailbox, ToolStripProgressBar bar, RichTextBox subject, RichTextBox body) {
			if (client.IsConnected) {
				client.SelectMailbox(mailbox);
				var messages = GetUnseenMessages(client);
				var count = messages.Count();

				if (count > 0) {
					bar.Maximum = count;
					LoopThroughMessages(client, messages, count, subject, body, bar);
				} else {
					Debug.WriteLine("No new mail has been found.");
				}
			}
		}
		public Lazy<MailMessage>[] GetUnseenMessages(ImapClient client) {
			var messages = client.SearchMessages(SearchCondition.Unseen());
			return messages;
		}

		public void LoopThroughMessages(ImapClient client, Lazy<MailMessage>[] messages, int count, RichTextBox subject, RichTextBox body, ToolStripProgressBar bar) {
			MailMessage[] mailMessage = new MailMessage[count];
			var j = 0;
			foreach (var item in messages) {
				var message = item.Value.Body;
				mailMessage[j] = item.Value;
				subject.Text = item.Value.Subject;
				body.Text = item.Value.Body;
				bar.PerformStep();
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
	}
}
