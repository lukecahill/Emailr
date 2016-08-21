using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows.Forms;

namespace Email_Application {
	public partial class AddNewEmailForm : Form {

		protected static IMongoClient _client;
		protected static IMongoDatabase _database;

		public AddNewEmailForm() {
			InitializeComponent();

			_client = new MongoClient();
			_database = _client.GetDatabase("test");
		}

		private void addNewEmailButton_Click(object sender, EventArgs e) {
			AddNewEmailAccount();
		}

		private void AddNewEmailAccount() {
			var username = addressTextbox.Text;
			var password = passwordTextbox.Text;
			var server = GetServer();
			var mailbox = mailboxTextbox.Text;
			var collection = _database.GetCollection<BsonDocument>("emailcredentials");

			var document = new BsonDocument {
				{ "username", username },
				{ "password", password },
				{ "server", server },
				{ "mailbox", mailbox }
			};
			collection.InsertOne(document);

			ResetForm();
		}

		private string GetServer() {
			var server = "";
			if(serverCombobox.SelectedIndex == 0) {
				server = "gmail";
			} else if(serverCombobox.SelectedIndex == 1) {
				server = "outlook";
			}

			return server;
		}

		private void ResetForm() {
			addressTextbox.Text = "";
			passwordTextbox.Text = "";
			mailboxTextbox.Text = "";
			serverCombobox.SelectedItem = 0;
		}
	}
}
