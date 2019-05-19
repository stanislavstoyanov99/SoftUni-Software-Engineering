using System;
using System.Collections.Generic;
using System.Linq;

namespace _08CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" -> ");
                string companyName = tokens[0];
                string employeeId = tokens[1];

                if (!database.ContainsKey(companyName))
                {
                    database.Add(companyName, new List<string>() { employeeId });
                }
                else if (!database[companyName].Contains(employeeId))
                {
                    database[companyName].Add(employeeId);
                }
            }

            foreach (var company in database.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{company.Key}");
                Console.WriteLine($"-- {string.Join(Environment.NewLine + "-- ", company.Value)}");
            }
        }
    }
}
