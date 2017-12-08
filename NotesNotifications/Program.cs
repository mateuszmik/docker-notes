using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace NotificationsService
{
        public class Program
        {
            public static void Main()
            {
                HostFactory.Run(x =>
                {
                    x.Service<NancySelfHost>(s =>
                    {
                        s.ConstructUsing(name => new NancySelfHost());
                        s.WhenStarted(tc => tc.Start());
                        s.WhenStopped(tc => tc.Stop());
                    });

                    x.RunAsLocalSystem();
                    x.SetDescription("NotificationsService");
                    x.SetDisplayName("NotificationsService");
                    x.SetServiceName("NotificationsService");
                });
            }
        }
}
