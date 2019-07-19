using System.Collections.Generic;

using P03.Detail_Printer.Interfaces;
using P03.Detail_Printer.Models;

namespace P03.DetailPrinter
{
    public class StartUp
    {
        public static void Main()
        {
            // Enter business logic

            IEmployee employee = new Employee("Kiro");
            IEmployee manager = new Manager("Pesho", new List<string> { "Tetradka", "Himikalka", "Klamer" });
            IEmployee accountManager = new AccountManager("Gosho");

            List<IEmployee> employees = new List<IEmployee>
            {
                employee,
                manager,
                accountManager
            };

            DetailsPrinter details = new DetailsPrinter(employees);
            details.PrintDetails();
        }
    }
}
