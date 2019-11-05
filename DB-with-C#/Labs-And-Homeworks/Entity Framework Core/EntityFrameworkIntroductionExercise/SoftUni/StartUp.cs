namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Text;
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Globalization;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var database = new SoftUniContext();

            using (database)
            {
                Console.WriteLine(RemoveTown(database));
            }
        }

        // Problem - 03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext db)
        {
            var employees = db.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                });

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
                .First(e => e.LastName == "Nakov");

            foundEmployee.Address = address;

            db.SaveChanges();

            var employees = db.Employees
                .OrderByDescending(e => e.AddressId)
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

        // Problem - 07. Employees and Projects 
        public static string GetEmployeesInPeriod(SoftUniContext db)
        {
            var employees = db.Employees
                .Where(e => e.EmployeesProjects
                .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
                    EmployeesProjects = e.EmployeesProjects
                    .Select(p => new
                    {
                        Name = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })
                    .ToList()
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FullName} - Manager: {employee.ManagerFullName}");

                foreach (var project in employee.EmployeesProjects)
                {
                    string projectStartDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt",
                        CultureInfo.InvariantCulture);

                    string projectEndDate = project.EndDate == null ?
                        "not finished" :
                        project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt",
                        CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{project.Name} - {projectStartDate} - {projectEndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 08. Addresses by Town 
        public static string GetAddressesByTown(SoftUniContext db)
        {
            var addresses = db.Addresses
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }
            
            return sb.ToString().TrimEnd();
        }

        // Problem - 09. Employee 147 
        public static string GetEmployee147(SoftUniContext db)
        {
            var employee = db.Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects
                    .Select(p => p.Project.Name)
                    .OrderBy(p => p)
                    .ToList()
                })
                .Where(e => e.Id == 147)
                .First();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"{project}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 10. Departments with More Than 5 Employees 
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext db)
        {
            var departments = db.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    Name = d.Name,
                    ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
                    EmployeesCount = d.Employees.Count,
                    Employees = d.Employees
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        JobTitle = e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFullName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 11. Find Latest 10 Projects 
        public static string GetLatestProjects(SoftUniContext db)
        {
            var lastTenStartedProjects = db.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate
                })
                .OrderBy(p => p.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in lastTenStartedProjects)
            {
                string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt",
                    CultureInfo.InvariantCulture);

                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{startDate}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 12. Find Latest 10 Projects 
        public static string IncreaseSalaries(SoftUniContext db)
        {
            List<Employee> employees = db.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                e.Department.Name == "Tool Design" ||
                e.Department.Name == "Marketing" ||
                e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            db.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext db)
        {
            var employees = db.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 14. Delete Project by Id 
        public static string DeleteProjectById(SoftUniContext db)
        {
            Project project = db.Projects.Find(2);

            List<EmployeeProject> employeesProjects = db.EmployeesProjects
                .Where(ep => ep.ProjectId == project.ProjectId)
                .ToList();

            db.EmployeesProjects.RemoveRange(employeesProjects);
            db.Projects.Remove(project);

            db.SaveChanges();

            StringBuilder sb = new StringBuilder();

            List<string> projectsToShow = db.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            foreach (var currentProject in projectsToShow)
            {
                sb.AppendLine(currentProject);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 15. Remove Town
        public static string RemoveTown(SoftUniContext db)
        {
            Town townToDelete = db.Towns
                .First(t => t.Name == "Seattle");

            List<Address> addressesToDelete = db.Addresses
                .Where(a => a.Town.Name == townToDelete.Name)
                .ToList();

            foreach (var address in addressesToDelete)
            {
                var employeesInCurrentAddress = db.Employees
                    .Where(e => e.Address.AddressId == address.AddressId);

                foreach (var employee in employeesInCurrentAddress)
                {
                    employee.AddressId = null;
                }
            }

            db.Addresses.RemoveRange(addressesToDelete);
            db.Towns.Remove(townToDelete);
            db.SaveChanges();

            return $"{addressesToDelete.Count} addresses in Seattle were deleted";
        }
    }
}
