using System;
using MailGunSendingService.Interfaces;

namespace MailGunSendingService.Services
{
    public class MailGunSendingTopService : IMailGunSendingTopService
	{
        public MailGunSendingTopService(IMailGunSendingService svc)
        {
            _mailerService = svc;
        }

        private readonly IMailGunSendingService _mailerService;

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
