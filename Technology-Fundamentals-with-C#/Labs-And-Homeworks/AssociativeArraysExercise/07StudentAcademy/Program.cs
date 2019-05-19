using System;
using System.Collections.Generic;
using System.Linq;

namespace _07StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Dictionary<string, List<double>>();

            int numberOfStudents = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfStudents; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (!database.ContainsKey(studentName))
                {
                    database.Add(studentName, new List<double>() { studentGrade });
                }
                else
                {
                    database[studentName].Add(studentGrade);
                }
            }

            var finalList = new Dictionary<string, double>();
            foreach (var item in database)
            {
                double averageGrade = item.Value.Average();
                if (averageGrade >= 4.50)
                {
                    finalList.Add(item.Key, averageGrade);
                }
            }

            foreach (var kvp in finalList.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:F2}");
            }
        }
    }
}
