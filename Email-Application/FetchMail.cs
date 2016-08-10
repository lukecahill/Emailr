using AE.Net.Mail;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Email_Application {
	public class FetchMail {
		
		protected static IMongoClient _client = new MongoClient();
		IMongoDatabase _database = _client.GetDatabase("test");

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
			var collection = _database.GetCollection<BsonDocument>("mycollection");
			MailMessage[] mailMessage = new MailMessage[count];
			var j = 0;
			foreach (var item in messages) {
				var message = item.Value.Body;
				mailMessage[j] = item.Value;
				bar.PerformStep();
				j++;

				var document = new BsonDocument {
					{ "body", item.Value.Body },
					{ "subject", item.Value.Subject },
					{ "to", item.Value.To.ToString() },
					{ "cc", item.Value.Cc.ToString() }
				};
				collection.InsertOneAsync(document);
			}
			//client.SetFlags(Flags.Seen, mailMessage);
			Debug.WriteLine("Mail has been fetched successfully!");
		}
	}
}
