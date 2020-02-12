namespace SulsApp.Controllers
{
    using System.Linq;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using Data;
    using Services;
    using ViewModels.Submissions;

    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly ApplicationDbContext db;

        public SubmissionsController(ISubmissionsService submissionsService, ApplicationDbContext db)
        {
            this.submissionsService = submissionsService;
            this.db = db;
        }

        [HttpGet]
        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.db.Problems
                .Where(x => x.Id == id)
                .Select(x => new SubmissionViewModel
                {
                    Name = x.Name,
                    ProblemId = x.Id
                }).FirstOrDefault();

            if (problem == null)
            {
                return this.Error("Problem not found!");
            }

            return this.View(problem);
        }

        [HttpPost]
        public HttpResponse Create(string code, string problemId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (code?.Length < 30 || code?.Length > 800)
            {
                return this.Redirect("/Submissions/Create");
            }

            this.submissionsService.CreateSubmission(code, problemId, this.User);
            return this.Redirect("/");
        }

        [HttpGet]
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.DeleteSubmission(id);
            return this.Redirect("/");
        }
    }
}
