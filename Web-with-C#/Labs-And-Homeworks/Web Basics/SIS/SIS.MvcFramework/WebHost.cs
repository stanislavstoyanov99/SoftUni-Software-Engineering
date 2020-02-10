namespace SIS.MvcFramework
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using HTTP;
    using HTTP.Logging;
    using HTTP.Response;
    using HTTP.Enumerations;

    public static class WebHost
    {
        public static async Task StartAsync(IMvcApplication application)
        {
            IList<Route> routeTable = new List<Route>();
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.Add<ILogger, ConsoleLogger>();

            application.ConfigureServices(serviceCollection);
            application.Configure(routeTable);
            AutoRegisterStaticFileRoutes(routeTable);
            AutoRegisterActionRoutes(routeTable, application, serviceCollection);

            var logger = serviceCollection.CreateInstance<ILogger>();
            Console.WriteLine("Registered routes:");
            foreach (var route in routeTable)
            {
                Console.WriteLine(route);
            }

            Console.WriteLine();
            Console.WriteLine("Requests:");

            var httpServer = new HttpServer(80, routeTable, logger);
            await httpServer.StartAsync();
        }

        // /{controller}/{action}/
        private static void AutoRegisterActionRoutes(IList<Route> routeTable, IMvcApplication application, IServiceCollection serviceCollection)
        {
            var controllers = application.GetType().Assembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Controller)) && !type.IsAbstract);

            foreach (var controller in controllers)
            {
                var actions = controller.GetMethods()
                    .Where(method => !method.IsSpecialName
                    && !method.IsConstructor
                    && method.IsPublic
                    && method.DeclaringType == controller);

                foreach (var action in actions)
                {
                    string url = "/" + controller.Name.Replace("Controller", string.Empty) + "/" + action.Name;

                    var attribute = action.GetCustomAttributes()
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
                    InvokeAction(request, serviceCollection, controller, action)));
                }
            }
        }

        private static HttpResponse InvokeAction(HttpRequest request,
            IServiceCollection serviceCollection,
            Type controllerType,
            MethodInfo actionMethod)
        {
            var controller = serviceCollection.CreateInstance(controllerType) as Controller;
            controller.Request = request;
            var response = actionMethod.Invoke(controller, new object[] { }) as HttpResponse;
            // TODO : add parameters to action in controller

            return response;
        }

        private static void AutoRegisterStaticFileRoutes(IList<Route> routeTable)
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
