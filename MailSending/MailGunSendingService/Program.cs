using MailGunSendingService.Interfaces;
using MailGunSendingService.Mappings;
using StructureMap;
using Topshelf;
using Topshelf.StructureMap;

namespace MailGunSendingService
{
    public static class Program
    {
        private static void Main()
        {
            using (var container = new Container(cfg => { cfg.AddRegistry<MailGunSendingStructureRegistry>(); }))
            {
                HostFactory.Run(c =>
                {
                    c.UseStructureMap(container);

                    c.Service<IMailGunSendingTopService>(s =>
                    {
                        s.ConstructUsingStructureMap();

                        s.WhenStarted((service, control) => service.Start());
                        s.WhenStopped((service, control) => service.Stop());
                    });

                    c.EnableServiceRecovery(r =>
                    {
                        r.RestartService(1);
                        r.RestartService(1);

                        r.SetResetPeriod(1);
                    });

                    c.StartAutomaticallyDelayed();
                    c.UseAssemblyInfoForServiceInfo();
                });
            }
        }
    }
}
