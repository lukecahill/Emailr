using System;

namespace Email_Application {
	public class EmailListBoxItem : Object {
		
		public string EmailId { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public string To { get; set; }
		public string Cc { get; set; }
		public string From { get; set; }
		public string DateTime { get; set; }
		public object Object { get; set; }

		public EmailListBoxItem(string id, string subject, string body, string to, string cc, string from, string datetime) {
			this.EmailId = id;
			this.Subject = subject;
			this.Body = body;
			this.To = to;
			this.Cc = cc;
			this.From = from;
			this.DateTime = datetime;
		}

		public EmailListBoxItem() {	}

		public EmailListBoxItem(object Object) {
			this.Subject = Object.ToString();
			this.Object = Object;
		}
		

		public override string ToString() {
			return this.Subject;
		}
	}
}
