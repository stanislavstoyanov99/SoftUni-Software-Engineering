﻿namespace SulsApp
{
    using System.Collections.Generic;

    using SIS.HTTP;
    using SIS.MvcFramework;
    using SIS.HTTP.Enumerations;

    using Data;
    using Controllers;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }

        public void Configure(IList<Route> routeTable)
        {
            routeTable.Add(new Route(HttpMethodType.Get, "/", new HomeController().Index));
            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Login", new UsersController().Login));
            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Register", new UsersController().Register));
        }
    }
}
