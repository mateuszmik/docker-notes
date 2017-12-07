using System;
using Nancy;

namespace NotificationsService
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => Response.AsText("Notifications Service");

            Get["/Status"] = _ => 
                DateTime.Now.Second % 10 == 0
                    ? new Response {StatusCode = HttpStatusCode.InternalServerError}
                    : Response.AsText("OK");

            Get["/Messages"] = _ =>
            {
                var response = Response.AsJson(MessagesQueue.GetAll());
                MessagesQueue.Clear();
                Console.WriteLine($"Returning messages: {response}");
                return response;
            };
        }
    }
}