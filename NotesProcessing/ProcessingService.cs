using System;
using System.Configuration;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using Messages;
using NATS.Client;

namespace ProcessingService
{
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
                    Msg msg = new Msg("notes", new NotesNotificationsMesasage() { MessageType = NotesMessageType.Succes, Message = "very big success" });
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