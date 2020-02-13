namespace IRunes.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.View();
            }

            var viewModel = this.homeService.GetUsername();

            return this.View(viewModel, "Home");
        }

        [HttpGet("/Home/Index")]
        public HttpResponse Home()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.homeService.GetUsername();

            return this.View(viewModel);
        }
    }
}
