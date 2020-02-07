namespace SIS.MvcFramework
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using HTTP;
    using HTTP.Enumerations;
    using SIS.HTTP.Response;
    using System.Linq;
    using System.Reflection;

    public static class WebHost
    {
        public static async Task StartAsync(IMvcApplication application)
        {
            var routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);
            AutoRegisterStaticFileRoutes(routeTable);
            AutoRegisterActionRoutes(routeTable, application);

            Console.WriteLine("Registered routes:");
            foreach (var route in routeTable)
            {
                Console.WriteLine(route);
            }

            Console.WriteLine();
            Console.WriteLine("Requests:");

            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        // /{controller}/{action}/
        private static void AutoRegisterActionRoutes(List<Route> routeTable, IMvcApplication application)
        {
            var types = application.GetType().Assembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Controller)) && !type.IsAbstract);

            foreach (var type in types)
            {
                var methods = type.GetMethods()
                    .Where(method => !method.IsSpecialName
                    && !method.IsConstructor
                    && method.IsPublic
                    && method.DeclaringType == type);

                foreach (var method in methods)
                {
                    string url = "/" + type.Name.Replace("Controller", string.Empty) + "/" + method.Name;

                    var attribute = method.GetCustomAttributes()
                        .FirstOrDefault(x => x.GetType()
                        .IsSubclassOf(typeof(HttpMethodAttribute)))
                        as HttpMethodAttribute;
                    var httpActionType = HttpMethodType.Get; // Default type of request

                    if (attribute != null)
                    {
                        httpActionType = attribute.Type;

                        if (attribute.Url != null)
                        {
                            url = attribute.Url; // Take url from attribute
                        }
                    }

                    routeTable.Add(new Route(httpActionType, url, (request) =>
                    {
                        var controller = Activator.CreateInstance(type) as Controller;
                        controller.Request = request;
                        var response = method.Invoke(controller, new object[] { }) as HttpResponse;
                        return response;
                    }));
                }
            }
        }

        private static void AutoRegisterStaticFileRoutes(List<Route> routeTable)
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
