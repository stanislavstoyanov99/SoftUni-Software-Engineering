namespace SharedTrip.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;
    using ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel inputModel)
        {
            var userId = this.usersService.GetUserId(inputModel.Username, inputModel.Password);

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);
            return this.Redirect("/Trips/All");
        }

        [HttpGet]
        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel inputModel)
        {
            // Validations from the exam description

            if (inputModel.Username.Length < 5 || inputModel.Username?.Length > 20)
            {
                return this.View();
            }

            if (inputModel.Password?.Length < 6)
            {
                return this.View();
            }

            if (string.IsNullOrEmpty(inputModel.Email))
            {
                return this.View();
            }

            // I tried to use the Error from the MvcFramework, but it did not show me the error message in the view

            if (this.usersService.IsUsernameUsed(inputModel.Username))
            {
                return this.View();
            }

            if (this.usersService.IsEmailUsed(inputModel.Email))
            {
                return this.View();
            }

            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.View();
            }

            this.usersService.CreateUser(inputModel.Username, inputModel.Email, inputModel.Password);

            return this.Redirect("/Users/Login");
        }

        [HttpGet]
        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/Trips/All");
        }
    }
}
