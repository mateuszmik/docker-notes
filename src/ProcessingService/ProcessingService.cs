using System;
using System.Configuration;
using System.Text;
using System.Threading;
using DockerNotesCommon;
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
            var messageAddress = ConfigurationService.GetQueuesEndpoint();
            Console.WriteLine($"Trying to connect to  {messageAddress}");
            
            using (var c = new ConnectionFactory().CreateConnection(messageAddress))
            {
                Console.WriteLine($"Processing Service successfully connected to  {messageAddress}");
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