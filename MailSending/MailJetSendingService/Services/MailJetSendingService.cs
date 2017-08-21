using System;
using System.Net;
using Mailjet.Client;
using Mailjet.Client.Resources;
using MailJetSendingService.Interfaces;
using MailJetSendingService.Models;
using Newtonsoft.Json.Linq;

namespace MailJetSendingService.Services
{
    public class MailJetSendingService : IMailJetSendingService
	{
		public bool TestMethod()
		{
			MailDto m = new MailDto();
			m.FromEmail = "test@nida.se";
			m.FromName = "Nida user";
			m.ToEmail = "nd@sql8r.net";
			m.ToName = "sql8r User";
			m.Subject = "Sending with MailJet is Fun";
			m.TextContent = "and easy to do anywhere, even with C#";
			m.HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>";

			return TestSendMethod(m);
		}

		private bool TestSendMethod(MailDto m)
		{
		    var k1 = "?"; // API Public Key (SMTP username)
            var k2 = "?"; // API Secret Key (SMTP password)


            MailjetClient client = new MailjetClient(k1, k2);
		    MailjetRequest request = new MailjetRequest
		        {
		            Resource = Send.Resource,
		        }
		        .Property(Send.FromEmail, m.FromEmail)
		        .Property(Send.FromName, m.FromName)
		        .Property(Send.Subject, m.Subject)
		        .Property(Send.TextPart, m.TextContent)
		        .Property(Send.HtmlPart, m.HtmlContent)
		        .Property(Send.Recipients, new JArray {
		            new JObject {
		                {"Email", "nd@sql8r.net"}
		            }
		        });

		    MailjetResponse r = client.PostAsync(request).Result;

		    if (r.IsSuccessStatusCode)
		    {
		        Console.WriteLine($"Total: {r.GetTotal()}, Count: {r.GetCount()}");
		        Console.WriteLine(r.GetData());
		    }
		    else
		    {
		        Console.WriteLine($"StatusCode: {r.StatusCode}");
		        Console.WriteLine($"ErrorInfo: {r.GetErrorInfo()}");
		        Console.WriteLine($"ErrorMessage: {r.GetErrorMessage()}");
		    }

		    return r.IsSuccessStatusCode;
		}

    }
}
