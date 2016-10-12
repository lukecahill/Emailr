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
		private ToolStripProgressBar _bar;
		private ListBox _emailList;
		ImapClient _imapClient;

		/// <summary>
		/// Constructor for the class FetchMail
		/// </summary>
		/// <param name="client">ImapClient variable, of the client being connected too</param>
		/// <param name="bar">ToolStripMenuBar which is used to update the progress bar on the main form.</param>
		/// <param name="emailList">ListBox which is populated with the emails found in the database.</param>
		public FetchMail(ImapClient client, ToolStripProgressBar bar, ListBox emailList) {
			_client = new MongoClient();
			_database = _client.GetDatabase("test");
			this._imapClient = client;

			this._bar = bar;
			this._emailList = emailList;
		}

		/// <summary>
		/// Selects the mailbox to search and gets any new messages. Updates the count of the messages found. 
		/// </summary>
		/// <param name="mailbox">String - The mailbox to search for new messages</param>
		/// <returns></returns>
		public int GetMessages(string mailbox) {
			
			if (_imapClient.IsConnected) {
				_imapClient.SelectMailbox(mailbox);
				var messages = GetUnseenMessages();
				var count = messages.Count();

				if (count > 0) {
					_bar.Maximum = count;
					var i = LoopThroughMessages(messages);
					return i;
				} else {
					Debug.WriteLine("No new mail has been found.");
					_bar.Value = _bar.Maximum;
					Thread.Sleep(2000);
					_bar.Value = 0;
				}
			}
			return 0;
		}

		/// <summary>
		/// Finds the unopened messages in the mailbox. 
		/// </summary>
		/// <returns>Lazy<MailMessage>[] - array containing the messages found</returns>
		public Lazy<MailMessage>[] GetUnseenMessages() {
			var messages = _imapClient.SearchMessages(SearchCondition.Unseen());
			return messages;
		}

		/// <summary>
		/// Iterates through the messages which are found. Parses them into the BsonDocuments and adds this to the email list box. Updates the progress bar as updating.
		/// </summary>
		/// <param name="messages">Lazy<MailMessage>[] - array of the found unread messages.</param>
		/// <returns></returns>
		public int LoopThroughMessages(Lazy<MailMessage>[] messages) {
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

				_emailList.Items.Add(email);
				_bar.PerformStep();
			}
			//client.SetFlags(Flags.Seen, mailMessage);
			Debug.WriteLine("Mail has been fetched successfully!");
			return i;
		}
	}
}
