using System;
using System.Threading;
using Nancy.Hosting.Self;

namespace NotificationsService
{
    internal class NancySelfHost
    {
        private const string Url = "http://localhost:1234";
        private NancyHost _host;

        public void Start()
        {
            //var thread = new Thread(QueueSubscriber.SubscribeToQueue);
            //thread.Start();
            _host = new NancyHost(new Uri(Url));
            _host.Start();
            Console.WriteLine($"Running on {Url}");
        }

        public void Stop()
        {
            _host.Stop();
        }
    }
}