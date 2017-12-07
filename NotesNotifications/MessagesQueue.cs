using System.Collections.Generic;
using NATS.Client;

namespace NotificationsService
{
    public static class MessagesQueue
    {
        private static IList<Msg> _listOfMessages = new List<Msg>();

        public static object GetAll() =>
            _listOfMessages;

        public static void Add(Msg msg) =>
            _listOfMessages.Add(msg);

        public static void Clear()
        {
            _listOfMessages = new List<Msg>();
        }
    }
}