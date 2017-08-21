using System;
using MailJetSendingService.Interfaces;

namespace MailJetSendingService.Services
{
    public class MailJetSendingTopService : IMailJetSendingTopService
	{
        public MailJetSendingTopService(IMailJetSendingService svc)
        {
            _mailerService = svc;
        }

        private readonly IMailJetSendingService _mailerService;

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
