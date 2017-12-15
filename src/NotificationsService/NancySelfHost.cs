using System;
using System.Threading;
using DockerNotesCommon;
using Nancy.Hosting.Self;

namespace NotificationsService
{
    internal class NancySelfHost
    {
        private string _url; 
        private NancyHost _host;

        public void Start()
        {
            _url = ConfigurationService.GetLocalNotificationsEndpoint();
            var thread = new Thread(QueueSubscriber.SubscribeToQueue);
            thread.Start();
            _host = new NancyHost(new Uri(_url));
            _host.Start();
            Console.WriteLine($"Running on {_url}");
        }

        public void Stop()
        {
            _host.Stop();
        }
    }
}