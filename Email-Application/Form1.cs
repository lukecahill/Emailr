using AE.Net.Mail;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_Application {
	public partial class emailrForm : Form {

		public int emailCount = 0;
		string username = "", password = "", mailbox = "", server = "";
		private bool emailOpen = false, sorted = false;

		ContextMenu emailListContextMenu;
		FetchMail _fetch;

		protected static IMongoClient _client;
		protected static IMongoDatabase _database;

		public emailrForm() {
			InitializeComponent();
			// this works but a better way should be found.
			// Control.Invoke is a better way of achieving this. As this can cause unexpected results. 
			CheckForIllegalCrossThreadCalls = false;

			_client = new MongoClient();
			_database = _client.GetDatabase("test");
			emailListContextMenu = new ContextMenu();

			CreateContextMenu();

			progressBar.Maximum = 100;
			progressBar.Minimum = 0;
			progressBar.Step = 1;
			emailList.DrawMode = DrawMode.Normal;
			replyButton.Enabled = false;
			forwardButton.Enabled = false;

			var getMailTimer = new System.Timers.Timer();
			getMailTimer.Elapsed += new ElapsedEventHandler(MailTimer);
			getMailTimer.Interval = 300000; // 5 minutes.
			getMailTimer.Enabled = true;

			// should be called last.
			GetDatabaseEmails();
		}

		/// <summary>
		/// Handler for when the user chooses the reply option in the email list context menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemReply_Click(object sender, EventArgs e) {

			if (emailList.SelectedIndex >= 0) {
				var item = (EmailListBoxItem)emailList.SelectedItem;
				messageBox.DocumentText = item.Body;
				subjectBox.Text = item.Subject;

				var replyForm = new ReplyForm(username, messageBox.DocumentText, subjectBox.Text, item.From, server, true);
				replyForm.Show();
			}
		}

		/// <summary>
		/// Handler for when the user chooses the delete option in the email list context menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemDelete_Click(object sender, EventArgs e) {
			if (emailList.SelectedIndex >= 0) {
				DeleteEmail();
			}
		}

		/// <summary>
		/// Handler for when the user chooses the open option in the email list context menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemOpen_Click(object sender, EventArgs e) {
			if (emailList.SelectedIndex >= 0) {
				var item = (EmailListBoxItem)emailList.SelectedItem;
				//var text = Regex.Replace(item.Body, "\n", "<br>");
				//messageBox.DocumentText = text;
				messageBox.DocumentText = item.Body;
				subjectBox.Text = item.Subject;
				fromLabel.Text = $"From: {item.From}";
				emailOpen = true;

				EnableButtons(emailOpen);
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
				_fetch = new FetchMail(client, progressBar, emailList);

				//if(InvokeRequired) {
				//	Invoke(new Action(() => {
				//		emailCount += FetchMail.GetMessages(client, mailbox, progressBar, emailList);
				//	}));
				//} else {
				//	emailCount += FetchMail.GetMessages(client, mailbox, progressBar, emailList);
				//}
				emailCount += _fetch.GetMessages(mailbox);
				emailListCountLabel.Text = $"Items: {emailCount}";
			}
		}

		/// <summary>
		/// Return all of the items found in the database, and insert them into a custom listbox item.
		/// </summary>
		public async void GetDatabaseEmails() {
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
							document["from"].ToString(),
							document["datetime"].ToString()
						);

						emailList.Items.Add(email);
						emailCount++;
					}
				}
			}
			emailListCountLabel.Text = $"Items: {emailCount}";
		}

		/// <summary>
		/// Finds the item in the database and deletes it. 
		/// </summary>
		public async void DeleteEmail() {
			// edit this to instead remove by the ID of the document.
			var item = (EmailListBoxItem)emailList.SelectedItem;
			var id = item.EmailId;

			var collection = _database.GetCollection<BsonDocument>("mycollection");
			var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
			var result = await collection.DeleteManyAsync(filter);

			// should also then update the listbox and the current count.
		}

		/// <summary>
		/// Calls the FetchMessages() function, to fetch any new messages
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fetchNewToolStripMenuItem_Click(object sender, EventArgs e) {
			Task.Factory.StartNew(() => GetCredentials());
		}

		/// <summary>
		/// Starts a new process of the same application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void newToolStripMenuItem_Click(object sender, EventArgs e) {
			var info = new ProcessStartInfo(Application.ExecutablePath);
			Process.Start(info);
		}

		/// <summary>
		/// Exits the programs process
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Environment.Exit(0);
		}

		/// <summary>
		/// Gets new email from the specified server. Disables the fetch new mail button while doing this.
		/// </summary>
		private void fetchNewMailButton_Click(object sender, EventArgs e) {
			fetchNewMailButton.Enabled = false;
			Task.Factory.StartNew(() => GetCredentials());
			fetchNewMailButton.Enabled = true;
			progressBar.Value = 0;
		}

		/// <summary>
		/// Shows the help for the program
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show("No point looking here for help. IDK what is happening here at the moment...");
		}

		/// <summary>
		/// Handler for when the user double clicks an email in the email list. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void emailList_MouseDoubleClick(object sender, MouseEventArgs e) {
			var item = (EmailListBoxItem)emailList.SelectedItem;
			fromLabel.Text = $"From: {item.From}";
			messageBox.DocumentText = item.Body;
			subjectBox.Text = item.Subject;
			emailOpen = true;

			EnableButtons(emailOpen);
		}

		/// <summary>
		/// Handler for the user right clicking on an item in the email list, which will then select that item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// Handler for showing the reply form when the reply button is clicked.
		/// Constucts the reply form and calls the show method on this form. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void replyButton_Click(object sender, EventArgs e) {
			var replyForm = new ReplyForm(username, messageBox.DocumentText, subjectBox.Text, fromLabel.Text, server, true);
			replyForm.Show();
		}

		/// <summary>
		/// Calls the search email function which then searches the database for the matching string. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void searchEmailButton_Click(object sender, EventArgs e) {
			SearchMessages();
		}

		/// <summary>
		/// Handler for if the key pressed is the return key. This then searches the messages.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void searchTextBox_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				SearchMessages();
			}
		}

		/// <summary>
		/// Searches the emails stored in the MongoDb for the text the user has entered into the searchbox. 
		/// Currently searches by the subject, body, and from fields in the database. 
		/// </summary>
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
							item["from"].ToString(),
							item["datetime"].ToString()
						);

				emailList.Items.Add(email);
				emailCount++;
			}
		}

		/// <summary>
		/// Shows the form where the user enters their reply/new email/forward.
		/// </summary>
		private void ShowNewEmailForm() {
			var newEmail = new ReplyForm();
			newEmail.Show();
		}

		/// <summary>
		/// Calls the ShowNewEmailForm() functon.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void newEmailButton_Click(object sender, EventArgs e) {
			ShowNewEmailForm();
		}

		/// <summary>
		/// Shows the reply email form, but instead allows the user to forward the email
		/// and so instantiates it with the username, subject, body, and who it is from.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void forwardButton_Click(object sender, EventArgs e) {
			var newEmail = new ReplyForm(username, messageBox.DocumentText, subjectBox.Text, fromLabel.Text, server, false);
			newEmail.Show();
		}

		/// <summary>
		/// Shows the form where the user can add a new email address to save.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void addNewEmailToolStripMenuItem_Click(object sender, EventArgs e) {
			var newEmailForm = new AddNewEmailForm();
			newEmailForm.Show();
		}

		/// <summary>
		/// Timer which is fired every 5 minutes to search the added emails for new emails.
		/// This is automatic.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void MailTimer(object source, ElapsedEventArgs e) {
			if (fetchNewMailButton.InvokeRequired) {
				fetchNewMailButton.Invoke(new MethodInvoker(delegate {
					Task.Factory.StartNew(() => GetCredentials());
				}));
			}
		}

		/// <summary>
		/// Calls the SortEmails function which sorts the emails in the list box.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void sortButton_Click(object sender, EventArgs e) {
			SortEmails();
		}

		/// <summary>
		/// Sorts the emails - this is sorted by either the subject, or the date/time of when the item was added to the database.
		/// Sort order is determined by the bool 'sorted'
		/// </summary>
		private void SortEmails() {
			var list = new List<EmailListBoxItem>();
			if (sorted) {
				list = emailList.Items.Cast<EmailListBoxItem>().OrderBy(x => x.Subject).ToList();
				sorted = false;
			} else {
				list = emailList.Items.Cast<EmailListBoxItem>().OrderBy(x => x.DateTime).ToList();
				sorted = true;
			}

			emailList.Items.Clear();

			foreach (var item in list) {
				emailList.Items.Add(item);
			}
		}

		/// <summary>
		/// Calls the ShowNewEmailForm() function.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void newEmailToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowNewEmailForm();
		}

		/// <summary>
		/// Gets the users email credentials which have been saved to the database.
		/// Currently only returns one item from the database.
		/// </summary>
		private async void GetCredentials() {
			var collection = _database.GetCollection<BsonDocument>("emailcredentials");
			var filter = new BsonDocument();
			var cursor = await collection.Find(filter).SingleAsync();

			username = cursor.AsBsonDocument[1].ToString();
			password = cursor.AsBsonDocument[2].ToString();
			server = cursor.AsBsonDocument[3].ToString();
			mailbox = cursor.AsBsonDocument[4].ToString();

			FetchMessages();
		}

		/// <summary>
		/// Toggles the reply & forward buttons.
		/// </summary>
		/// <param name="enabled">bool of whether the buttons should be enabled or not</param>
		private void EnableButtons(bool enabled) {
			if (enabled) {
				replyButton.Enabled = true;
				forwardButton.Enabled = true;
			} else {
				replyButton.Enabled = false;
				forwardButton.Enabled = false;
			}
		}

		/// <summary>
		/// Creates the context menu which is displayed when the user right clicks an email in the list.
		/// </summary>
		private void CreateContextMenu() {
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
		}
	}
}
