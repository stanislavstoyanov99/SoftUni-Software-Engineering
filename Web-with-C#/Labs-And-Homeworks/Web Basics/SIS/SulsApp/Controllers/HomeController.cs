namespace SulsApp.Controllers
{
    using System.Linq;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using Data;
    using ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.View();
            }

            var problems = this.db.Problems.Select(x => new IndexProblemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count
            }).ToList();

            var loggedInViewModel = new LoggedInViewModel
            {
                Problems = problems
            };

            return this.View(loggedInViewModel, "IndexLoggedIn");
        }
    }
}
