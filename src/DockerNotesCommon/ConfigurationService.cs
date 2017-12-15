using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerNotesCommon
{
    public class ConfigurationService
    {
        public static string GetNotificationsEndpoint()
        {
            var notificationsUrl = Environment.GetEnvironmentVariable("DN-NOTIFICATIONS-URL") ?? "http://localhost:1234/Messages";

            return notificationsUrl;
        }

        public static string GetQueuesEndpoint()
        {
            var notificationsUrl = Environment.GetEnvironmentVariable("DN-QUEUES-ENDPOINT") ?? "nats://notesqueue:4222";

            return notificationsUrl;
        }
    }
}
