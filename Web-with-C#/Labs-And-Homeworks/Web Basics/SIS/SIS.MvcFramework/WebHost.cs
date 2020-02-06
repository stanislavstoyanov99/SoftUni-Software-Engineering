namespace SIS.MvcFramework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using HTTP;
    using HTTP.Enumerations;
    using SIS.HTTP.Response;

    public static class WebHost
    {
        public static async Task StartAsync(IMvcApplication application)
        {
            var routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);
            AutoRegisterRoutes(routeTable, application);

            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        private static void AutoRegisterRoutes(List<Route> routeTable, IMvcApplication application)
        {
            var staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);

            foreach (var staticFile in staticFiles)
            {
                var path = staticFile
                    .Replace(@"wwwroot", string.Empty)
                    .Replace("\\", "/");
                routeTable.Add(new Route(HttpMethodType.Get, path, (request) =>
                {
                    var fileInfo = new FileInfo(staticFile);
                    var contentType = fileInfo.Extension switch
                    {
                        ".css" => "text/css",
                        ".js" => "text/javascript",
                        ".ico" => "image/x-icon",
                        ".jpg" => "image/jpeg",
                        ".jpeg" => "image/jpeg",
                        ".png" => "image/png",
                        ".gif" => "image/gif",
                        _ => "text/plain"
                    };

                    return new FileResponse(File.ReadAllBytes(staticFile), contentType);
                }));
            }
        }
    }
}
