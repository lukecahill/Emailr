using System;

namespace Email_Application {
	public class EmailListBoxItem : Object {

		public int EmailId { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public string To { get; set; }
		public string Cc { get; set; }
		public object Object { get; set; }
		
		public EmailListBoxItem(string subject, string body, string to, string cc) {
			this.Subject = subject;
			this.Body = body;
			this.To = to;
			this.Cc = cc;
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
