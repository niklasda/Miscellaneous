using MailGunSendingService.Interfaces;
using MailGunSendingService.Services;
using StructureMap;

namespace MailGunSendingService.Mappings
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

            For<IMailGunSendingTopService>().Use<MailGunSendingTopService>();
        }
    }
}
