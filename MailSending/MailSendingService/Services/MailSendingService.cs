using System;
using System.Net;
using MailSendingService.Interfaces;
using MailSendingService.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MailSendingService.Services
{
    public class MailSendingService : IMailSendingService
	{
		public bool TestMethod()
		{
			MailDto m = new MailDto();
			m.FromEmail = "test@nida.se";
			m.FromName = "Nida user";
			m.ToEmail = "nd@sql8r.net";
			m.ToName = "sql8r User";
			m.Subject = "Sending with SendGrid is Fun";
			m.TextContent = "and easy to do anywhere, even with C#";
			m.HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>";

			return TestSendMethod(m);
		}

		private bool TestSendMethod(MailDto m)
		{
			var apiKey = "?";
			var client = new SendGridClient(apiKey);

			var from = new EmailAddress(m.FromEmail, m.FromName);
			var subject = m.Subject;
			var to = new EmailAddress(m.ToEmail, m.ToName);
			var plainTextContent = m.TextContent;
			var htmlContent = m.HtmlContent;

			var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

			var r = client.SendEmailAsync(msg).Result;
		    Console.WriteLine(r.StatusCode.ToString());
            return r.StatusCode == HttpStatusCode.Accepted;
		}
	}
}
