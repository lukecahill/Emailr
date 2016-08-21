using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Diagnostics;
using System.Net.Mail;

namespace Email_Application {
	public class Mail {

		string username = "", password = "";

		protected static IMongoClient _client;
		protected static IMongoDatabase _database;

		public Mail() {
			_client = new MongoClient();
			_database = _client.GetDatabase("test");
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
					}
				}
			}
		}

		public bool SendMailOutlook(string subject, string body, string to, string from) {
			throw new NotImplementedException();
		}

		public bool SendMailGoogle(string subject, string body, string to, string from) {
			try {
				var mail = new MailMessage();
				var smtpServer = new SmtpClient("smtp.gmail.com");

				mail.From = new MailAddress(from);
				mail.To.Add(to);
				mail.Subject = subject;
				mail.Body = body;

				smtpServer.Port = 587;
				smtpServer.Credentials = new System.Net.NetworkCredential(username, password);
				smtpServer.EnableSsl = true;

				smtpServer.Send(mail);
				Debug.WriteLine("Mail sent");
				return true;

			} catch (Exception ex) {
				Debug.WriteLine(ex.ToString());
				return false;
			}
		}

	}
}
