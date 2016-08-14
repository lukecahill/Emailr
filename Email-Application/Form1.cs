using AE.Net.Mail;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Email_Application {
	public partial class emailrForm : Form {
		
		public int emailCount = 0;
		string username = "", password = "", mailbox = "", server = "gmail";

		ContextMenu emailListContextMenu = new ContextMenu();

		protected static IMongoClient _client;
		protected static IMongoDatabase _database;

		public emailrForm() {
			InitializeComponent();

			_client = new MongoClient();
			_database = _client.GetDatabase("test");

			progressBar.Maximum = 100;
			progressBar.Minimum = 0;
			progressBar.Step = 1;
			emailList.DrawMode = DrawMode.Normal;

			var itemOpen = new MenuItem();
			itemOpen.Text = "&Open";

			var itemDelete = new MenuItem();
			itemDelete.Text = "&Delete";

			var itemReply = new MenuItem();
			itemReply.Text = "&Reply";

			itemOpen.Click += ItemOpen_Click;
			itemDelete.Click += ItemDelete_Click;
			itemReply.Click += ItemReply_Click;

			emailListContextMenu.MenuItems.Add(itemOpen);
			emailListContextMenu.MenuItems.Add(itemReply);
			emailListContextMenu.MenuItems.Add(itemDelete);
			emailList.ContextMenu = emailListContextMenu;
			QueryMongo();
		}

		public string MessageSubjectBox {
			get { return this.subjectBox.Text; }
			set { this.subjectBox.Text = value; }
		}

		public string MessageBodyBox {
			get { return this.messageBox.Text; }
			set { this.messageBox.Text = value; }
		}

		private void ItemReply_Click(object sender, EventArgs e) {
			Debug.WriteLine("Not impletemed yet.");
			
			if (emailList.SelectedIndex >= 0) {
				var item = (EmailListBoxItem)emailList.SelectedItem;
				messageBox.DocumentText = item.Body;
				subjectBox.Text = item.Subject;
				
				var replyForm = new ReplyForm(username, messageBox.DocumentText, subjectBox.Text, item.From);
				replyForm.Show();
			}
		}

		private void ItemDelete_Click(object sender, EventArgs e) {
			if (emailList.SelectedIndex >= 0) {
				DeleteEmail();
			}
		}

		private void ItemOpen_Click(object sender, EventArgs e) {
			if (emailList.SelectedIndex >= 0) {
				var item = (EmailListBoxItem)emailList.SelectedItem;
				//var text = Regex.Replace(item.Body, "\n", "<br>");
				//messageBox.DocumentText = text;
				messageBox.DocumentText = item.Body;
				subjectBox.Text = item.Subject;
				fromLabel.Text = $"From: {item.From}";
			}
		}

		/// <summary>
		/// Starts the fetching of new messages. Client logs in here.
		/// </summary>
		private void FetchMessages() {
			using (var client = new ImapClient()) {
				if (server == "gmail") {
					client.Connect("imap.gmail.com", 993, true, true);
					mailbox = "inbox";
				} else if (server == "outlook") {
					client.Connect("outlook.office365.com", 993, true, true);
					mailbox = "Inbox";
				} else if (server == "yahoo") {
					client.Connect("", 993, true, true);
					mailbox = "Inbox";
				}

				client.Login(username, password);
				emailCount += FetchMail.GetMessages(client, mailbox, progressBar, emailList);
				emailListCountLabel.Text = $"Items: {emailCount}";
			}
		}

		/// <summary>
		/// Return all of the items found in the database, and insert them into a custom listbox item.
		/// </summary>
		public async void QueryMongo() {
			emailCount = 0;
			var collection = _database.GetCollection<BsonDocument>("mycollection");
			var filter = new BsonDocument();
			using (var cursor = await collection.FindAsync(filter)) {
				while (await cursor.MoveNextAsync()) {
					var batch = cursor.Current;
					foreach (var document in batch) {
						var email = new EmailListBoxItem(
							document["temp_id"].ToString(),
							document["subject"].ToString(),
							document["body"].ToString(),
							document["to"].ToString(),
							document["cc"].ToString(),
							document["from"].ToString()
						);

						emailList.Items.Add(email);
						emailCount++;
					}
				}
			}
			emailListCountLabel.Text = $"Items: {emailCount}";
		}

		public async void DeleteEmail() {
			// edit this to instead remove by the ID of the document.
			var item = (EmailListBoxItem)emailList.SelectedItem;
			var id = item.EmailId;

			var collection = _database.GetCollection<BsonDocument>("mycollection");
			var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
			var result = await collection.DeleteManyAsync(filter);

			// should also then update the listbox and the current count.
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

		/// <summary>
		/// Gets new email from the specified server. Disables the fetch new mail button while doing this.
		/// </summary>
		private void fetchNewMailButton_Click(object sender, EventArgs e) {
			fetchNewMailButton.Enabled = false;
			GetCredentials();
			fetchNewMailButton.Enabled = true;
			progressBar.Value = 0;
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show("No point looking here for help. IDK what is happening here at the moment...");
		}

		private void emailList_MouseDoubleClick(object sender, MouseEventArgs e) {
			var item = (EmailListBoxItem)emailList.SelectedItem;
			fromLabel.Text = $"From: {item.From}";
			messageBox.DocumentText = item.Body;
			subjectBox.Text = item.Subject;
		}

		private void emailList_MouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				Debug.WriteLine("right click");
				var item = emailList.IndexFromPoint(e.Location);
				if (item >= 0) {
					emailList.SelectedItem = item;
					emailListContextMenu.Show(emailList, e.Location);
				}
			}
		}

		private void replyButton_Click(object sender, EventArgs e) {
			var replyForm = new ReplyForm(username, messageBox.DocumentText, subjectBox.Text, fromLabel.Text);
			replyForm.Show();
		}

		private void searchEmailButton_Click(object sender, EventArgs e) {
			SearchMessages();
		}

		private void searchTextBox_KeyUp(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Enter) {
				SearchMessages();
			}
		}

		private async void SearchMessages() {
			emailCount = 0;
			var text = searchTextBox.Text;
			var collection = _database.GetCollection<BsonDocument>("mycollection");
			var builder = Builders<BsonDocument>.Filter;
			var filter = builder.Regex("subject", new BsonRegularExpression(text)) | builder.Regex("body", new BsonRegularExpression(text)) | builder.Regex("from", new BsonRegularExpression(text));
			var result = await collection.Find(filter).ToListAsync();

			emailList.Items.Clear();

			foreach (var item in result) {
				var email = new EmailListBoxItem(
							item["temp_id"].ToString(),
							item["subject"].ToString(),
							item["body"].ToString(),
							item["to"].ToString(),
							item["cc"].ToString(),
							item["from"].ToString()
						);

				emailList.Items.Add(email);
				emailCount++;
			}
		}

		private void ShowNewEmailForm() {
			var newEmail = new ReplyForm();
			newEmail.Show();
		}

		private void newEmailButton_Click(object sender, EventArgs e) {
			ShowNewEmailForm();
		}

		private void addNewEmailToolStripMenuItem_Click(object sender, EventArgs e) {
			var newEmailForm = new AddNewEmailForm();
			newEmailForm.Show();
		}

		private void newEmailToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowNewEmailForm();
		}

		private async void GetCredentials() {
			var collection = _database.GetCollection<BsonDocument>("emailcredentials");
			var filter = new BsonDocument();
			using (var cursor = await collection.FindAsync(filter)) {
				while (await cursor.MoveNextAsync()) {
					var batch = cursor.Current;
					foreach (var document in batch) {
						username = document["username"].ToString();
						password = document["password"].ToString();
						server = document["server"].ToString();
						mailbox = document["mailbox"].ToString();
					}
				}
			}

			FetchMessages();
		}
	}
}
