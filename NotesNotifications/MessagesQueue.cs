using System.Collections.Generic;
using System.Linq;
using NATS.Client;

namespace NotificationsService
{
    public static class MessagesQueue
    {
        private static IList<Msg> _listOfMessages = new List<Msg>();

        public static IReadOnlyCollection<string> GetAll() =>
            _listOfMessages
                .Select(x => System.Text.Encoding.Default.GetString(x.Data))
                .ToList();

        public static void Add(Msg msg) =>
            _listOfMessages.Add(msg);

        public static void Clear()
        {
            _listOfMessages = new List<Msg>();
        }
    }
}