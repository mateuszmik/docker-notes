using System;
using System.Configuration;
using NATS.Client;

namespace NotificationsService
{
    internal static class QueueSubscriber
    {
        private static string messageAddress = ConfigurationManager.AppSettings.Get("message-queue");
        private static IConnection c = c = new ConnectionFactory().CreateConnection(messageAddress);

        public static void SubscribeToQueue()
        {

            try
            {
                Console.WriteLine($"Trying to connect to  {messageAddress}");
                Console.WriteLine($"Successfully connected to  {messageAddress}");

                IAsyncSubscription s = c.SubscribeAsync("foo");
                s.MessageHandler += (sender, args) =>
                {
                    Console.WriteLine("Received: " + args.Message);
                    MessagesQueue.Add(args.Message);
                };
                s.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to connect to queueing server. will continue without it.");
            }
        }

        public static void MessageHandler(object sender, MsgHandlerEventArgs e)
        {
            Console.WriteLine($"received message {e.Message.Data}");
        }

    }
}