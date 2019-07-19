using System;
using System.Collections.Generic;

using P03.Detail_Printer.Interfaces;

namespace P03.Detail_Printer.Models
{
    public class DetailsPrinter : IDetailsPrinter
    {
        private readonly IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IEmployee employee in this.employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
