using MailSendingService.Interfaces;
using MailSendingService.Services;
using StructureMap;

namespace MailSendingService.Mappings
{
    public class MailSendingStructureRegistry : Registry
    {
        public MailSendingStructureRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });

            For<IMailSendingTopService>().Use<MailSendingTopService>();
        }
    }
}
