using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class NotesNotificationsMesasage
    {
        public string Message { get; set; }
        public NotesMessageType MessageType { get; set; }
        public Guid Guid { get; set; }
        public DateTime GeneratedOn { get; set; }

        public NotesNotificationsMesasage()
        {
            Guid = Guid.NewGuid();
            GeneratedOn = DateTime.Now;
        }

    }

    public enum NotesMessageType
    {
        Succes = 0,
        Failure = 1,
    }
}
