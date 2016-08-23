using AE.Net.Mail;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Email_Application {
	public class FetchMail {

		private static IMongoClient _client;
		private static IMongoDatabase _database;

		public FetchMail() {
			_client = new MongoClient();
			_database = _client.GetDatabase("test");
		}

		public int GetMessages(ImapClient client, string mailbox, ToolStripProgressBar bar, ListBox emailList) {
			
			if (client.IsConnected) {
				client.SelectMailbox(mailbox);
				var messages = GetUnseenMessages(client);
				var count = messages.Count();

				if (count > 0) {
					bar.Maximum = count;
					var i = LoopThroughMessages(client, messages, count, bar, emailList);
					return i;
				} else {
					Debug.WriteLine("No new mail has been found.");
					bar.Value = bar.Maximum;
					Thread.Sleep(2000);
					bar.Value = 0;
				}
			}
			return 0;
		}

		public Lazy<MailMessage>[] GetUnseenMessages(ImapClient client) {
			var messages = client.SearchMessages(SearchCondition.Unseen());
			return messages;
		}

		public int LoopThroughMessages(ImapClient client, Lazy<MailMessage>[] messages, int count, ToolStripProgressBar bar, ListBox emailList) {
			var collection = _database.GetCollection<BsonDocument>("mycollection");
			var i = 0;
			foreach (var item in messages) {
				i++;

				var document = new BsonDocument {
					{ "temp_id", i },
					{ "body", item.Value.Body },
					{ "subject", item.Value.Subject },
					{ "to", item.Value.To.ToString() },
					{ "cc", item.Value.Cc.ToString() },
					{ "from", item.Value.From.Address.ToString() },
					{ "datetime", item.Value.Date.ToUniversalTime() }
				};
				collection.InsertOneAsync(document);

				var email = new EmailListBoxItem(
					document["temp_id"].ToString(),
					document["subject"].ToString(),
					document["body"].ToString(),
					document["to"].ToString(),
					document["cc"].ToString(),
					document["from"].ToString(),
					document["datetime"].ToString()
				);

				emailList.Items.Add(email);
				bar.PerformStep();
			}
			//client.SetFlags(Flags.Seen, mailMessage);
			Debug.WriteLine("Mail has been fetched successfully!");
			return i;
		}
	}
}
