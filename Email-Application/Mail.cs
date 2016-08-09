using System.Net.Mail;
using System.Collections.Generic;

namespace Email_Application {
	public class Mail {
		public int MailId { get; set; }
		public string MailBody { get; set; }
		public string MailSubject { get; set; }
		public ICollection<MailAddress> MailToAddress { get; set; }
		public ICollection<MailAddress> MailCCAddresses { get; set; }
	}
}
