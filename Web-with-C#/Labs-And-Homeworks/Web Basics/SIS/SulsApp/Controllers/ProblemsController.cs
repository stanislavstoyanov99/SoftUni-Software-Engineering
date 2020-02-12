namespace SulsApp.Controllers
{
    using System.Linq;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using Data;
    using Services;
    using ViewModels.Problems;

    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ApplicationDbContext db;

        public ProblemsController(IProblemsService problemsService, ApplicationDbContext db)
        {
            this.problemsService = problemsService;
            this.db = db;
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

            var viewModel = this.db.Problems
                .Where(x => x.Id == id)
                .Select(x => new DetailsViewModel
                {
                    Name = x.Name,
                    Problems = x.Submissions.Select(x => new ProblemSubmissionViewModel
                    {
                        Username = x.User.Username,
                        AchievedResult = x.AchievedResult,
                        MaxPoints = x.Problem.Points,
                        CreatedOn = x.CreatedOn,
                        SubmissionId = x.Id
                    })
                    .ToList()
                })
                .FirstOrDefault();

            return this.View(viewModel);
        }
    }
}
