using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var users = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = input.Split(":");
                string contest = tokens[0];
                string passwordForContest = tokens[1];

                contests.Add(contest, passwordForContest);
            }

            string secondInput = string.Empty;
            while ((secondInput = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = secondInput.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string userName = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(userName))
                    {
                        users.Add(userName, new Dictionary<string, int>());

                        if (!users[userName].ContainsKey(contest))
                        {
                            users[userName].Add(contest, points);
                        }
                        else
                        {
                            CheckPoints(users, contest, userName, points);
                        }
                    }
                    else
                    {
                        if (!users[userName].ContainsKey(contest))
                        {
                            users[userName].Add(contest, points);
                        }
                        else
                        {
                            CheckPoints(users, contest, userName, points);
                        }
                    }
                }
            }

            foreach (var item in users.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value.Values.Sum()} points.");
                Console.WriteLine("Ranking: ");
                foreach (var student in users.OrderBy(x => x.Key))
                {
                    Console.WriteLine(student.Key);

                    foreach (var subjects in student.Value.OrderByDescending(x => x.Value))
                    {
                        Console.WriteLine($"#  {subjects.Key} -> {subjects.Value}");
                    }
                }

                break;
            }
        }

        private static void CheckPoints(Dictionary<string, Dictionary<string, int>> users, string contest, string userName, int points)
        {
            if (points > users[userName][contest])
            {
                users[userName][contest] = points;
            }
        }
    }
}
