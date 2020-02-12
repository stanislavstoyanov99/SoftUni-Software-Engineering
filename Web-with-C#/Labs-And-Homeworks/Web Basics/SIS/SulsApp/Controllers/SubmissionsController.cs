namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;

    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(ISubmissionsService submissionsService)
        {
            this.submissionsService = submissionsService;
        }

        [HttpGet]
        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.submissionsService.GetProblem(id);

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

            this.submissionsService.Create(code, problemId, this.User);
            return this.Redirect("/");
        }

        [HttpGet]
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
