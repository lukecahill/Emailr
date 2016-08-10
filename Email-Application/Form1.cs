using AE.Net.Mail;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Email_Application {
	public partial class emailrForm : Form {

		FetchMail fetch = null;
		string server = "gmail";
		int emailCount = 0;
		protected static IMongoClient _client;
		protected static IMongoDatabase _database;

		public emailrForm() {
			InitializeComponent();

			fetch = new FetchMail();
			_client = new MongoClient();
			_database = _client.GetDatabase("test");

			progressBar.Maximum = 100;
			progressBar.Minimum = 0;
			progressBar.Step = 1;
			emailList.DrawMode = DrawMode.Normal;
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

		public async void queryMongo() {
			emailCount = 0;
			var collection = _database.GetCollection<BsonDocument>("mycollection");
			var filter = new BsonDocument();
			using (var cursor = await collection.FindAsync(filter)) {
				while (await cursor.MoveNextAsync()) {
					var batch = cursor.Current;
					foreach (var document in batch) {
						var email = new EmailListBoxItem(document["subject"].ToString(), document["body"].ToString(), document["to"].ToString(), document["cc"].ToString());
						emailList.Items.Add(email);
						emailCount++;
					}
				}
			}
			emailListCountLabel.Text = $"Number of emails: {emailCount}";
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
			//FetchMessages();
			queryMongo();
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show("No point looking here for help. IDK what is happening here at the moment...");
		}

		private void emailList_MouseDoubleClick(object sender, MouseEventArgs e) {
			var item = (EmailListBoxItem)emailList.SelectedItem;
			richTextBox1.Text = item.Body;
			richTextBox2.Text = item.Subject;
		}
	}
}
