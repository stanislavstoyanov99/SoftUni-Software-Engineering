namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;
    using ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.View();
            }

            var problems = this.problemsService.GetProblems();

            var loggedInViewModel = new LoggedInViewModel
            {
                Problems = problems
            };

            return this.View(loggedInViewModel, "IndexLoggedIn");
        }
    }
}
