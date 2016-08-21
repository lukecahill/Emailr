using AE.Net.Mail;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Email_Application {
	public static class FetchMail {
		
		private static IMongoClient _client = new MongoClient();
		static IMongoDatabase _database = _client.GetDatabase("test");

		public static int GetMessages(ImapClient client, string mailbox, ToolStripProgressBar bar, ListBox emailList) {
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
					//Invoke(new Action(() => {
					//	bar.Value = bar.Maximum;
					//	Thread.Sleep(2000);
					//	bar.Value = 0;
					//}));
					bar.Value = bar.Maximum;
					Thread.Sleep(2000);
					bar.Value = 0;
				}
			}
			return 0;
		}
		public static Lazy<MailMessage>[] GetUnseenMessages(ImapClient client) {
			var messages = client.SearchMessages(SearchCondition.Unseen());
			return messages;
		}

		public static int LoopThroughMessages(ImapClient client, Lazy<MailMessage>[] messages, int count, ToolStripProgressBar bar, ListBox emailList) {
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
