namespace Andreys.App
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using Data;
    using Services;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> serverRoutingTable)
        {
            using var db = new AndreysDbContext();
            db.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProductsService, ProductsService>();
        }
    }
}
