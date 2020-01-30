namespace DemoApp
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SIS.HTTP;
    using SIS.HTTP.Response;
    using SIS.HTTP.Constants;
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
            routeTable.Add(new Route(HttpMethodType.Get, "/users/folders", Folders));
            routeTable.Add(new Route(HttpMethodType.Post, "/users/folders/processFolder", ShowFolders));

            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        // GET 
        private static HttpResponse Folders(HttpRequest request)
        {
            var htmlBuilder = new StringBuilder();

            htmlBuilder.AppendLine(@"<meta charset=""utf-8"">" + "<h1>Movies directories:</h1>");
            htmlBuilder.AppendLine(@"<form action=""/users/folders/processFolder""method=""post"">Path to show:<input type=""text"" name=""pathname""><br><br><input type=""submit"" value=""Find""></form>");

            byte[] htmlAsBytes = Encoding.UTF8.GetBytes(htmlBuilder.ToString());
            var response = new HtmlResponse(htmlBuilder.ToString());
            response.Body = htmlAsBytes;

            return response;
        }

        // POST 
        private static HttpResponse ShowFolders(HttpRequest request)
        {
            string path = request.Body.Split('=')[1];

            string formattedPath = WebUtility.UrlDecode(path.Replace("\r\n", ""));
            var directories = Directory.GetDirectories(formattedPath);

            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine(@"<meta charset=""utf-8"">");

            int counter = 1;
            foreach (var folder in directories)
            {
                htmlBuilder.Append($"<p>{counter}. {folder}</p>" + HttpConstants.NewLine);
                counter++;
            }

            htmlBuilder.AppendLine(@"<form action=""/users/folders""> <input type=""submit"" value=""Go to Folders Page""></form>");

            var response = new HtmlResponse(htmlBuilder.ToString());
            return response;
        }

        // GET
        private static HttpResponse Index(HttpRequest request)
        {
            var username = request
                .SessionData
                .ContainsKey("Username") ? request.SessionData["Username"] : "Anonymous";

            return new HtmlResponse($"<h1>Home page. Hello, {username}</h1>" +
                $"<a href='/users/login'>Go to login page</a>");
        }

        // POST
        private static HttpResponse LoggedUser(HttpRequest request)
        {
            string[] path = request.Body.Split(new string[] { "=", "&"}, StringSplitOptions.None);
            string firstName = path[1];
            string lastName = path[3].Replace("\r\n", String.Empty);

            request.SessionData["Username"] = firstName;

            return new HtmlResponse($"<h1>Home page. Hello, {firstName} {lastName}</h1>");
        }

        // GET
        private static HttpResponse Login(HttpRequest request)
        {
            var response = new HtmlResponse(@"<h1>login page</h1><form action=""/users/login"" method=""post""> <input type=""submit"" value=""Go to Login Form""></form>");
            return response;
        }

        // POST
        private static HttpResponse DoLogin(HttpRequest request)
        {
            string body = @"<form action=""/"" method=""post"">First Name:<br><input type=""text"" name=""firstnmame""><br>Last Name:<br><input type=""text"" name=""lastname""><br><br><input type=""submit"" value=""Login""></form>";
            byte[] bodyAsBytes = Encoding.UTF8.GetBytes(body);
            var response = new HtmlResponse(body);
            response.Body = bodyAsBytes;

            return response;
        }

        private static HttpResponse FavIcon(HttpRequest request)
        {
            var byteContent = File.ReadAllBytes("wwwroot/favicon.ico");
            return new FileResponse(byteContent, "image/x-icon");
        }
    }
}
