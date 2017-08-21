using MailJetSendingService.Interfaces;
using MailJetSendingService.Services;
using StructureMap;

namespace MailJetSendingService.Mappings
{
    public class MailGunSendingStructureRegistry : Registry
    {
        public MailGunSendingStructureRegistry()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });

            For<IMailJetSendingTopService>().Use<MailJetSendingTopService>();
        }
    }
}
