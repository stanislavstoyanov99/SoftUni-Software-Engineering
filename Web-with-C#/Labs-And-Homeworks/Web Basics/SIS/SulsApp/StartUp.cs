namespace SulsApp
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using Data;
    using Services;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            // Middleware
            var db = new ApplicationDbContext();
            db.Database.Migrate();
        }
    }
}
