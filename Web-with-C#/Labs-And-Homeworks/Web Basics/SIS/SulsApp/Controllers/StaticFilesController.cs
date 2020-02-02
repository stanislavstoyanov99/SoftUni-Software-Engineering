namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class StaticFilesController : Controller
    {
        public HttpResponse Bootstrap(HttpRequest request)
        {
            return this.CssFileView("bootstrap.min");
        }

        public HttpResponse Site(HttpRequest request)
        {
            return this.CssFileView("site");
        }

        public HttpResponse Reset(HttpRequest request)
        {
            return this.CssFileView("reset-css");
        }
    }
}
