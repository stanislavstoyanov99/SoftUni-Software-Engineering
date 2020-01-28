namespace DemoApp
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SIS.HTTP;
    using SIS.HTTP.Response;
    using SIS.HTTP.Enumerations;

    public class Program
    {
        public static async Task Main()
        {
            var routeTable = new List<Route>();
            routeTable.Add(new Route(HttpMethodType.Get, "/", Index));
            routeTable.Add(new Route(HttpMethodType.Get, "/users/login", Login));
            routeTable.Add(new Route(HttpMethodType.Post, "/users/login", DoLogin));
            routeTable.Add(new Route(HttpMethodType.Get, "/favicon.ico", FavIcon));

            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        private static HttpResponse Index(HttpRequest httpRequest)
        {
            return new HtmlResponse("<h1>home page</h1>");
        }

        private static HttpResponse Login(HttpRequest httpRequest)
        {
            return new HtmlResponse("<h1>login page</h1>");
        }

        private static HttpResponse DoLogin(HttpRequest httpRequest)
        {
            return new HtmlResponse("<h1>login page form</h1>");
        }

        private static HttpResponse FavIcon(HttpRequest httpRequest)
        {
            throw new NotImplementedException();
        }
    }
}
