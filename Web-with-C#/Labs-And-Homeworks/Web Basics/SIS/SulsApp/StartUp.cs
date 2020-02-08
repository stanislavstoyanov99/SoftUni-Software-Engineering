namespace SulsApp
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using Data;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices() // IServiceCollection serviceCollection
        {
            // TODO : Add dependency container
        }

        public void Configure(IList<Route> routeTable)
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();
        }
    }
}
