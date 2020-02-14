namespace IRunes.App.Services
{
    using System.Linq;

    using Data;
    using ViewModels.Home;

    public class HomeService : IHomeService
    {
        private readonly RunesDbContext db;

        public HomeService(RunesDbContext db)
        {
            this.db = db;
        }

        public LoggedInViewModel GetUsername(string id)
        {
            var username = this.db.Users
                .Where(x => x.Id == id)
                .Select(x => new LoggedInViewModel
                {                  
                    Username = x.Username
                })
                .FirstOrDefault();

            return username;
        }
    }
}
