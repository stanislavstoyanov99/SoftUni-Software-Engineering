using System;
using System.Collections.Generic;
using System.Linq;

namespace _10SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsAndPoints = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = input.Split("-");
                string userName = tokens[0];

                if (tokens[1] == "banned")
                {
                    studentsAndPoints.Remove(userName);
                }
                else
                {
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);

                    if (!studentsAndPoints.ContainsKey(userName))
                    {
                        studentsAndPoints[userName] = points;
                    }
                    else if (points > studentsAndPoints[userName])
                    {
                        studentsAndPoints[userName] = points;
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions[language] = 1;
                        // submissions[language] = 0;
                    }
                    // without else part we can directly iterate it
                    else
                    {
                        submissions[language]++;
                    }
                }
            }

            Console.WriteLine("Results:");
            foreach (var kvp in studentsAndPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var kvp in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
