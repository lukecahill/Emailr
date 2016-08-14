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
			var server = serverTextbox.Text;
			var mailbox = mailboxTextbox.Text;
			var collection = _database.GetCollection<BsonDocument>("emailcredentials");

			var document = new BsonDocument {
				{ "username", username },
				{ "password", password },
				{ "server", server },
				{ "mailbox", mailbox }
			};
			collection.InsertOne(document);
		}
	}
}
