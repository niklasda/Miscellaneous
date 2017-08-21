using System;
using MailSendingService.Interfaces;

namespace MailSendingService.Services
{
    public class MailSendingTopService : IMailSendingTopService
	{
        public MailSendingTopService(IMailSendingService svc)
        {
            _mailerService = svc;
        }

        private readonly IMailSendingService _mailerService;

        public bool Start()
        {
	        bool ok = _mailerService.TestMethod();
            Console.WriteLine($"Success?: {ok}");

            return true;
        }

        public bool Stop()
        {

            return true;
        }
    }
}
