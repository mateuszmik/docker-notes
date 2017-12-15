using System;
using System.Configuration;
using DockerNotesCommon;
using NATS.Client;

namespace NotificationsService
{
    internal static class QueueSubscriber
    {
        private static readonly string MessageAddress = ConfigurationService.GetQueuesEndpoint();
        private static readonly IConnection Connection = new ConnectionFactory().CreateConnection(MessageAddress);

        public static void SubscribeToQueue()
        {
            try
            {
                Console.WriteLine($"Trying to connect to  {MessageAddress}");
                Console.WriteLine($"Notifications Service Successfully connected to  {MessageAddress}");

                var subscription = Connection.SubscribeAsync("notes");
                subscription.MessageHandler += MessageHandler();
                subscription.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to connect to queueing server on {MessageAddress}. will continue without it.", ex);
            }
        }

        private static EventHandler<MsgHandlerEventArgs> MessageHandler()
        {
            return (sender, args) =>
            {
                Console.WriteLine($"Received: {args.Message}");
                MessagesQueue.Add(args.Message);
            };
        }
    }
}