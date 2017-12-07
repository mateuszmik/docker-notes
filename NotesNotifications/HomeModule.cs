using System;
using Nancy;

namespace NotificationsService
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                return Response.AsText("Notifications Service");
            };

            Get["/Status"] = _ =>
            {
                if (DateTime.Now.Second % 10 == 0)
                {
                    var response = new Response();
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    return response;
                }
                else
                {
                    return Response.AsText("OK");
                }
                    
            };

            Get["/Messages"] = _ =>
            {
                var response = Response.AsJson(MessagesQueue.GetAll());
                Console.WriteLine("Returning messages: " + response);
                MessagesQueue.Clear();
                return response;
            };
        }

    }
}