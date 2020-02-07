﻿namespace SulsApp
{
    using System.Collections.Generic;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using Data;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }

        public void Configure(IList<Route> routeTable)
        {
        }
    }
}
