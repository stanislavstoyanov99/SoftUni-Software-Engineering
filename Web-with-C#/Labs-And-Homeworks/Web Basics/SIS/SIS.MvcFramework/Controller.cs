namespace SIS.MvcFramework
{
    using System.IO;
    using System.Runtime.CompilerServices;

    using HTTP;
    using HTTP.Response;

    public abstract class Controller
    {
        protected HttpResponse View<TModel>(TModel viewModel = null, [CallerMemberName]string viewName = null)
            where TModel : class
        {
            IViewEngine viewEngine = new ViewEngine();

            var controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            var html = File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");
            html = viewEngine.GetHtml(html, viewModel);

            var layout = File.ReadAllText("Views/Shared/_Layout.html");
            var bodyWithLayout = layout.Replace("@RenderBody()", html);
            bodyWithLayout = viewEngine.GetHtml(bodyWithLayout, viewModel);

            return new HtmlResponse(bodyWithLayout);
        }

        protected HttpResponse View([CallerMemberName]string viewName = null)
        {
            return this.View<object>(null, viewName);
        }

        protected HttpResponse CssFileView(string fileName)
        {
            var fileContent = File.ReadAllBytes("wwwroot/css/" + $"{fileName}" + ".css"); 

            return new FileResponse(fileContent, "text/css");
        }
    }
}
