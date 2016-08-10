using System;
using System.Diagnostics;
using System.Net.Mail;

namespace Email_Application {
	public class Mail {

		public Mail() { }

		public bool sendMail(string subject, string body, string to, string from) {
			try {
				var mail = new MailMessage();
				var smtpServer = new SmtpClient("smtp.gmail.com");

				mail.From = new MailAddress(from);
				mail.To.Add(to);
				mail.Subject = subject;
				mail.Body = body;

				smtpServer.Port = 587;
				smtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
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
