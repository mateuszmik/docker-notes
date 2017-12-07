using System;
using System.Threading;
using Nancy.Hosting.Self;

namespace NotificationsService
{
    internal class NancySelfHost
    {
        private NancyHost host;

        public void Start()
        {
            Thread t=  new Thread(new ThreadStart(QueueSubscriber.SubscribeToQueue));
            t.Start();
            host = new NancyHost(new Uri("http://localhost:1234"));
            host.Start();
            Console.WriteLine("Running on http://localhost:1234");

           


        }

       
        public void Stop()
        {
            host.Stop();
        }
    }
}