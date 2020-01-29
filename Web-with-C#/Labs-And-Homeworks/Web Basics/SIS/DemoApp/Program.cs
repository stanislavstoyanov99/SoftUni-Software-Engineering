namespace DemoApp
{
    using System.IO;
    using System.Text;
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
            routeTable.Add(new Route(HttpMethodType.Post, "/", LoggedUser));
            routeTable.Add(new Route(HttpMethodType.Get, "/users/login", Login));
            routeTable.Add(new Route(HttpMethodType.Post, "/users/login", DoLogin));
            routeTable.Add(new Route(HttpMethodType.Get, "/favicon.ico", FavIcon));

            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        private static HttpResponse Index(HttpRequest request)
        {
            var username = request
                .SessionData
                .ContainsKey("Username") ? request.SessionData["Username"] : "Anonymous";

            return new HtmlResponse($"<h1>Home page. Hello, {username}</h1>" +
                $"<a href='/users/login'>Go to login page</a>");
        }

        private static HttpResponse LoggedUser(HttpRequest request)
        {
            var username = request
                .SessionData
                .ContainsKey("Username") ? request.SessionData["Username"] : "Anonymous";

            return new HtmlResponse($"<h1>Home page. Hello, {username}</h1>");
        }

        private static HttpResponse Login(HttpRequest request)
        {
            var response = new HtmlResponse(@"<h1>login page</h1><form action=""/users/login"" method=""post""> <input type=""submit"" value=""Go to Login Form""></form>");
            return response;
        }

        private static HttpResponse DoLogin(HttpRequest request)
        {
            string body = @"<form action=""/"" method=""post"">First Name:<br><input type=""text"" name=""firstname""><br>Last Name:<br><input type=""text"" name=""lastname""><br><br><input type=""submit"" value=""Login""></form>";
            byte[] bodyAsBytes = Encoding.UTF8.GetBytes(body);
            var response = new HtmlResponse(body);
            response.Body = bodyAsBytes;

            request.SessionData["Username"] = "Pesho";

            return response;
        }

        private static HttpResponse FavIcon(HttpRequest request)
        {
            var byteContent = File.ReadAllBytes("wwwroot/favicon.ico");
            return new FileResponse(byteContent, "image/x-icon");
        }
    }
}
