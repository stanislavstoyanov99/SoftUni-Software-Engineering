namespace Andreys.Controllers
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
                return this.Error("You are already logged in.");
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
            return this.Redirect("/Home/Home");
        }

        [HttpGet]
        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Error("You are already registered.");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel inputModel)
        {
            if (inputModel.Username?.Length < 4 || inputModel.Username?.Length > 10)
            {
                return this.Redirect("/Users/Register");
            }

            if (inputModel.Password?.Length < 6)
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.IsUserNameUsed(inputModel.Username))
            {
                return this.Error("Username is already used.");
            }

            if (this.usersService.IsEmailUsed(inputModel.Email))
            {
                return this.Error("Emal is already used.");
            }

            if (string.IsNullOrEmpty(inputModel.Email))
            {
                return this.Error("Email cannot be empty.");
            }

            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Error("Passwords should match.");
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
            return this.Redirect("/");
        }
    }
}
