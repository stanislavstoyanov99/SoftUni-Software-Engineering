namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.HTTP.Response;

    public class HomeController
    {
        public HttpResponse Index(HttpRequest request)
        {
            return new HtmlResponse("<h1>Hello</h1>");
        }
    }
}
