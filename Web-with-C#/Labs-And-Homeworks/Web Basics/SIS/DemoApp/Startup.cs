namespace DemoApp
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using SIS.HTTP;
    using SIS.HTTP.Constants;
    using SIS.HTTP.Enumerations;
    using SIS.HTTP.Response;

    using SIS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }

        public void Configure(IList<Route> routeTable)
        {
            routeTable.Add(new Route(HttpMethodType.Get, "/", Index));
            routeTable.Add(new Route(HttpMethodType.Post, "/", LoggedUser));
            routeTable.Add(new Route(HttpMethodType.Post, "/Tweets/Create", CreateTweet));
            routeTable.Add(new Route(HttpMethodType.Get, "/users/login", Login));
            routeTable.Add(new Route(HttpMethodType.Post, "/users/login", DoLogin));
            routeTable.Add(new Route(HttpMethodType.Get, "/favicon.ico", FavIcon));
            routeTable.Add(new Route(HttpMethodType.Get, "/users/folders", Folders));
            routeTable.Add(new Route(HttpMethodType.Post, "/users/folders/processFolder", ShowFolders));
        }

        // HomeController
        private static HttpResponse Index(HttpRequest request)
        {
            var username = request
                .SessionData
                .ContainsKey("Username") ? request.SessionData["Username"] : "Anonymous";

            var db = new ApplicationDbContext();
            var tweets = db.Tweets
                .Select(x => new
                {
                    x.CreatedOn,
                    x.Creator,
                    x.Content
                })
                .ToList();

            StringBuilder html = new StringBuilder();
            html.Append("<table><tr><th>Date</th><th>Creator</th><th>Content</th></tr>");
            foreach (var tweet in tweets)
            {
                html.Append($"<tr><td>{tweet.CreatedOn}</td><td>{tweet.Creator}</td><td>{tweet.Content}</td></tr>");
            }

            html.Append("</table>");
            html.Append($"<h1>Home page. Hello, {username}</h1>" +
                $"<a href='/users/login'>Go to login page</a>" +
                $"<form action='/Tweets/Create' method='post'><input name='creator' /><br /><textarea name='tweetName'></textarea><br /><input type='submit'/></form>");

            return new HtmlResponse(html.ToString());
        }

        // /Tweets => Index
        // /Tweets/Create => Create
        private static HttpResponse CreateTweet(HttpRequest request)
        {
            var db = new ApplicationDbContext();
            db.Tweets.Add(new Tweet
            {
                CreatedOn = DateTime.UtcNow,
                Creator = request.FormData["creator"],
                Content = request.FormData["tweetName"]
            });
            db.SaveChanges();

            return new RedirectResponse("/");
        }

        // GET 
        private static HttpResponse Folders(HttpRequest request)
        {
            var htmlBuilder = new StringBuilder();

            htmlBuilder.AppendLine(@"<meta charset=""utf-8"">" + "<h1>Movies directories:</h1>");
            htmlBuilder.AppendLine(@"<form action=""/users/folders/processFolder""method=""post"">Path to show:<input type=""text"" name=""pathname""><br><br><input type=""submit"" value=""Find""></form>");

            return new HtmlResponse(htmlBuilder.ToString());
        }

        // POST 
        private static HttpResponse ShowFolders(HttpRequest request)
        {
            string path = request.Body.Split('=')[1];

            string formattedPath = WebUtility.UrlDecode(path.Replace("\r\n", ""));
            var folders = Directory.GetDirectories(formattedPath);

            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine(@"<meta charset=""utf-8"">");

            int counter = 1;
            foreach (var folder in folders)
            {
                htmlBuilder.Append($"<p>{counter}. {folder}</p>" + HttpConstants.NewLine);
                counter++;
            }

            htmlBuilder.AppendLine(@"<form action=""/users/folders""> <input type=""submit"" value=""Go to Folders Page""></form>");

            return new HtmlResponse(htmlBuilder.ToString());
        }

        // POST
        private static HttpResponse LoggedUser(HttpRequest request)
        {
            string[] path = request.Body.Split(new string[] { "=", "&" }, StringSplitOptions.None);
            string firstName = path[1];
            string lastName = path[3].Replace("\r\n", String.Empty);

            request.SessionData["Username"] = firstName;

            return new HtmlResponse($"<h1>Home page.</h1><p>Hello, {firstName} {lastName}!</p>" +
                 $"<a href='/users/login'>Back to login page</a>");
        }

        // GET
        private static HttpResponse Login(HttpRequest request)
        {
            string html = @"<h1>login page</h1><form action=""/users/login"" method=""post""> <input type=""submit"" value=""Go to Login Form""></form>";

            return new HtmlResponse(html);
        }

        // POST
        private static HttpResponse DoLogin(HttpRequest request)
        {
            string html = @"<form action=""/"" method=""post"">First Name:<br><input type=""text"" name=""firstnmame""><br>Last Name:<br><input type=""text"" name=""lastname""><br><br><input type=""submit"" value=""Login""></form>";

            return new HtmlResponse(html);
        }

        // GET
        private static HttpResponse FavIcon(HttpRequest request)
        {
            var byteContent = File.ReadAllBytes("wwwroot/favicon.ico");
            return new FileResponse(byteContent, "image/x-icon");
        }
    }
}
