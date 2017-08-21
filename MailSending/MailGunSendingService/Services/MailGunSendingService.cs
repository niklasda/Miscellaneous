using System;
using System.Net;
using MailGunSendingService.Interfaces;
using MailGunSendingService.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace MailGunSendingService.Services
{
    public class MailGunSendingService : IMailGunSendingService
	{
		public bool TestMethod()
		{
			MailDto m = new MailDto();
			m.FromEmail = "test@nida.se";
			m.FromName = "Nida user";
			m.ToEmail = "nd@sql8r.net";
			m.ToName = "sql8r User";
			m.Subject = "Sending with MailGun is NOT Fun";
			m.TextContent = "and easy to do anywhere, even with C#";
			m.HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>";

			return TestSendMethod(m);
		}

        private bool TestSendMethod(MailDto m)
	    {
	        var apiKey = "?";

            RestClient client = new RestClient();
	        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
	        client.Authenticator = new HttpBasicAuthenticator("api", apiKey);

	        RestRequest request = new RestRequest();
	        request.AddParameter("domain", "nida.se", ParameterType.UrlSegment);
	        request.Resource = "{domain}/messages";
	        request.AddParameter("from", "nida <nd@nida.se>");
	        request.AddParameter("to", m.ToEmail);
	        //request.AddParameter("to", "YOU@YOUR_DOMAIN_NAME");
	        request.AddParameter("subject", m.Subject);
	        request.AddParameter("text", m.TextContent);
	        request.Method = Method.POST;

            var r =  client.Execute(request);
            Console.WriteLine(r.StatusCode.ToString());
	        return r.StatusCode == HttpStatusCode.Accepted;
	    }
    }
}
