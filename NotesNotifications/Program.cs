using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NATS.Client;
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


    public static class MessagesQueue
    {
        private static IList<Msg> _listOfMessages = new List<Msg>();

        public static object GetAll()
        {
            return _listOfMessages;
        }

        public static void Add(Msg msg)
        {
            _listOfMessages.Add(msg);
        }

        public static void Clear()
        {
            _listOfMessages = new List<Msg>();
        }
    }

}
