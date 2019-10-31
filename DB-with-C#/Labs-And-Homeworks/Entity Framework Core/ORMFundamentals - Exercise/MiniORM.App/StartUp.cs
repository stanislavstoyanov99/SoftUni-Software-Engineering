namespace MiniORM.App
{
    using System.Linq;
    using MiniORM.App.Data;
    using MiniORM.App.Data.Entities;

    public class StartUp
    {
        private static string connectionString = @"Server=.\SQLEXPRESS;Database=MiniORM;Integrated Security=True";

        public static void Main(string[] args)
        {
            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employees
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            Employees employee = context.Employees.Last();
            context.Employees.Remove(employee);

            context.SaveChanges();
        }
    }
}
