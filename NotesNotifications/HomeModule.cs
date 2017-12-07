using System;
using System.Linq;
using Nancy;

namespace NotificationsService
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            this.EnableCors();

            Get["/"] = _ => Response.AsText("Notifications Service");

            Get["/Status"] = _ => 
                DateTime.Now.Second % 10 == 0
                    ? new Response {StatusCode = HttpStatusCode.InternalServerError}
                    : Response.AsText("OK");

            Get["/Messages"] = _ =>
            {
                //var result = MessagesQueue.GetAll();
                var result = new[] {"dede"};
                MessagesQueue.Clear();
                Console.WriteLine($"Returning messages: {result.Select(x => x)}");
                return Response.AsJson(result);
            };
        }
    }
}