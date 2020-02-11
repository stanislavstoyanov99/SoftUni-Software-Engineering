namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SulsApp.Services;

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
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
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
    }
}
