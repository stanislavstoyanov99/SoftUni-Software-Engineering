﻿namespace SharedTrip
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            using var db = new ApplicationDbContext();
            db.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ITripsService, TripsService>();
        }
    }
}
