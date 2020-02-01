namespace SulsApp
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SIS.HTTP;
    using SIS.HTTP.Enumerations;

    using Controllers;

    public class Program
    {
        public static async Task Main()
        {
            var db = new ApplicationDbContext();

            var routeTable = new List<Route>();
            routeTable.Add(new Route(HttpMethodType.Get, "/", new HomeController().Index));

            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }
    }
}
