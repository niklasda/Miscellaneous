using System;

namespace MailSendingService.Models
{
    public class MailDto
    {
	    public string FromEmail { get; set; }
	    public string FromName { get; set; }
	    public string ToEmail { get; set; }
	    public string ToName { get; set; }
	    public string Subject { get; set; }
	    public string TextContent { get; set; }
	    public string HtmlContent { get; set; }
    }
}
