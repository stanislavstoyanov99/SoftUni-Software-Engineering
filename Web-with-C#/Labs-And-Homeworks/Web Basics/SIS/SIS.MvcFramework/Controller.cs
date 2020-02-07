﻿namespace SIS.MvcFramework
{
    using System.IO;
    using System.Text;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;

    using HTTP;
    using HTTP.Response;

    public abstract class Controller
    {
        public HttpRequest Request { get; set; }

        protected HttpResponse View<TModel>(TModel viewModel = null, [CallerMemberName]string viewName = null)
            where TModel : class
        {
            var controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            var viewPath = "Views/" + controllerName + "/" + viewName + ".html";

            return this.ViewByName<TModel>(viewPath, viewModel);
        }

        protected HttpResponse View([CallerMemberName]string viewName = null)
        {
            return this.View<object>(null, viewName);
        }

        private HttpResponse ViewByName<T>(string viewPath, object viewModel)
        {
            IViewEngine viewEngine = new ViewEngine();
            var html = File.ReadAllText(viewPath);
            html = viewEngine.GetHtml(html, viewModel);

            var layout = File.ReadAllText("Views/Shared/_Layout.html");
            var bodyWithLayout = layout.Replace("@RenderBody()", html);
            bodyWithLayout = viewEngine.GetHtml(bodyWithLayout, viewModel);
            return new HtmlResponse(bodyWithLayout);
        }

        protected HttpResponse Error(string error)
        {
            return this.ViewByName<ErrorViewModel>("Views/Shared/Error.html", new ErrorViewModel { Error = error });
        }

        protected HttpResponse Redirect(string url)
        {
            return new RedirectResponse(url);
        }

        protected string Hash(string input)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));

            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
