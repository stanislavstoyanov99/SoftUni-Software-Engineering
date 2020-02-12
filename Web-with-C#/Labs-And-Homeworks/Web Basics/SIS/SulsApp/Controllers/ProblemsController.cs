namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;

    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet]
        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (name?.Length < 5 || name?.Length > 20)
            {
                return this.Redirect("/Problems/Create");
            }

            if (points < 50 || points > 300)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemsService.CreateProblem(name, points);

            return this.Redirect("/");
        }

        [HttpGet]
        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.problemsService.GetDetailsProblems(id);

            return this.View(viewModel);
        }
    }
}
