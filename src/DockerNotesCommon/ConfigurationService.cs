using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerNotesCommon
{
    public class ConfigurationService
    {
        public static string GetLocalNotificationsEndpoint()
        {
            var notificationsUrl = "http://localhost:81";

            return notificationsUrl;
        }


        public static string GetNotificationsEndpoint()
        {
            var notificationsUrl = Environment.GetEnvironmentVariable("DN_NOTIFICATIONS_URL",EnvironmentVariableTarget.Machine) ?? "NOTSET";
            return notificationsUrl;
        }

        public static string GetQueuesEndpoint()
        {
            var notificationsUrl = Environment.GetEnvironmentVariable("DN_QUEUES_ENDPOINT") ?? "nats://notesqueue:4222";

            return notificationsUrl;
        }
    }
}
