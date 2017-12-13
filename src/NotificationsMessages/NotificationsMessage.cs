using System;

namespace NotificationsMessages
{
    public class NotificationsMessage
    {
        public string Message { get; set; }
        public string MessageType { get; set; }
        public Guid Guid { get; set; }
        public DateTime GeneratedOn { get; set; }

        public NotificationsMessage()
        {
            Guid = Guid.NewGuid();
            GeneratedOn = DateTime.Now;
        }
    }
}