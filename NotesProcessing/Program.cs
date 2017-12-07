using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NATS.Client;
using Topshelf;

namespace ProcessingService
{
    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<ProcessingService>(s =>
                {
                    s.ConstructUsing(name => new ProcessingService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("NotesProcessing");
                x.SetDisplayName("NotesProcessing");
                x.SetServiceName("NotesProcessing");
            });
        }
    }


    internal class ProcessingService
    {

        public void Start()
        {
            Thread t= new Thread(new ThreadStart(Run));
            t.Start();
        }

        private void Run()
        {
            var messageAddress = ConfigurationManager.AppSettings.Get("message-queue");
            using (IConnection c = new ConnectionFactory().CreateConnection(messageAddress))
            {
                while (true)
                {
                    Thread.Sleep(3000);
                    Msg msg = new Msg("notes");
                    msg.Data = Encoding.ASCII.GetBytes($"This is a note sent on {DateTime.Now}"); ;

                    c.Publish(msg);
                    Console.WriteLine("Message sent");
                }
            }
        }


        public void Stop()
        {
        }
    }
}
