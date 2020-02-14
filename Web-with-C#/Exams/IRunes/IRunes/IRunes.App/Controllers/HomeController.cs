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
            if (this.IsUserLoggedIn())
            {
                var viewModel = this.homeService.GetUsername(this.User);

                return this.View(viewModel, "Home");
            }

            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse Home()
        {
            return this.Index();
        }
    }
}
