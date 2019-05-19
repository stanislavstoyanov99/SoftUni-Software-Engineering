using System;
using System.Collections.Generic;
using System.Linq;

namespace _06Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split(" : ");
                string courseName = tokens[0];
                string studetName = tokens[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>() { studetName });
                    //courses[courseName].Add(studetName);
                }
                else
                {
                    courses[courseName].Add(studetName);
                }
            }

            foreach (var course in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                Console.WriteLine($"-- {string.Join(Environment.NewLine + "-- ", course.Value.OrderBy(x => x))}");
            }
        }
    }
}
