using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());

            List<Department> departments = new List<Department>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string name = tokens[0];
                double salary = double.Parse(tokens[1]);
                string departmentName = tokens[2];

                if (!departments.Any(d => d.DepartmentName == departmentName)) // check whether the department name does not exist
                {
                    departments.Add(new Department(departmentName));
                }

                // if the department exist, find the department name and add new employee
                departments.Find(d => d.DepartmentName == departmentName).AddNewEmployee(name, salary);
            }

            // make new object and the order the average salary (total salary / the number of employees)
            Department bestDepartment = departments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            // make new list and store the salary of each employee ordered by descending
            var highestAverageSalaries = bestDepartment.Employees.OrderByDescending(e => e.Salary).ToList();

            highestAverageSalaries.ForEach(e => Console.WriteLine($"{e.Name} {e.Salary:F2}"));
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }
    }

    class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>(); // create property that makes new list of employees
        public double TotalSalaries { get; set; }

        public Department(string departmentName)
        {
            DepartmentName = departmentName;
        }
        public void AddNewEmployee(string empName, double empSalary) // method that adds new employees to the Employees list and sums total salary
        {
            TotalSalaries += empSalary;
            Employees.Add(new Employee(empName, empSalary));
        }
    }
}
