namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var database = new SoftUniContext();

            using (database)
            {
                Console.WriteLine(AddNewAddressToEmployee(database));
            }
        }

        // Problem - 03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext db)
        {
            var employees = db.Employees
                .Select(e => new
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                string name = employee.FirstName;
                string lastName = employee.LastName;
                string middleName = employee.MiddleName;
                string jobTitle = employee.JobTitle;
                decimal salary = employee.Salary;

                sb.AppendLine($"{name} {lastName} {middleName} {jobTitle} {salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 04. Employees with Salary Over 50 000 
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext db)
        {
            var employees = db.Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary
                })
                .Where(e => e.Salary > 50_000)
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 05. Employees from Research and Development 
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext db)
        {
            var employees = db.Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary
                })
                .Where(e => e.DepartmentName == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 06. Adding a New Address and Updating Employee 
        public static string AddNewAddressToEmployee(SoftUniContext db)
        {
            Address address = new Address
            {
                TownId = 4,
                AddressText = "Vitoshka 15"
            };

            Employee foundEmployee = db.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            foundEmployee.Address = address;

            db.SaveChanges();

            var employees = db.Employees
                .OrderByDescending(e => e.Address.AddressId)
                .Select(e => new
                {
                    AddressText = e.Address.AddressText
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
