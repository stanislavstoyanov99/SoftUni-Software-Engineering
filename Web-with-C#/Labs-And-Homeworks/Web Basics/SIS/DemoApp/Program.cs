namespace DemoApp
{
    using System;
    using System.Threading.Tasks;

    using SIS.HTTP;

    public class Program
    {
        public static async Task Main()
        {
            // Actions:
            // / => response IndexPage(request)
            // /favicon.ico => favicon.ico
            // GET /Contact => response ShowContactForm(request)
            // POST /Contact => response FillContactForm(request)

            var httpServer = new HttpServer(80);
            await httpServer.StartAsync();
        }
    }
}
