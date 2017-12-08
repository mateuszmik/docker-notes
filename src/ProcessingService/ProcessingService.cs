using System;
using System.Configuration;
using System.Text;
using System.Threading;
using NATS.Client;

namespace ProcessingService
{
    internal class ProcessingService
    {
        public void Start()
        {
            var thread = new Thread(Run);
            thread.Start();
        }

        private static void Run()
        {
            var messageAddress = ConfigurationManager.AppSettings.Get("message-queue");
            using (var c = new ConnectionFactory().CreateConnection(messageAddress))
            {
                while (true)
                {
                    Thread.Sleep(3000);
                    var msg = new Msg("notes")
                    {
                        Data = Encoding.ASCII.GetBytes($"This is a note sent on {DateTime.Now}")
                    };

                    c.Publish(msg);
                    Console.WriteLine("Message sent");
                }
            }
        }

        public void Stop() { }
    }
}