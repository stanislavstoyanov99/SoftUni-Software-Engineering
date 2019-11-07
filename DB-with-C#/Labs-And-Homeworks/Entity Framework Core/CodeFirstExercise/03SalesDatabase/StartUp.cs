namespace P_03SalesDatabase
{
    using Microsoft.EntityFrameworkCore;

    using P03_SalesDatabase.Data;
    using P03_SalesDatabase.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new SalesContext();

            db.Database.Migrate();

            var sale = new Sale
            {
                ProductId = 2,
                CustomerId = 2,
                StoreId = 3
            };

            db.Sales.Add(sale);

            db.SaveChanges();
        }
    }
}
