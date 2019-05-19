using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Dictionary<string, Dictionary<string, int>>();
            var individualStandings = new Dictionary<string, int>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] tokens = input.Split(" -> ");
                string userName = tokens[0];
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!database.ContainsKey(contest))
                {
                    database.Add(contest, new Dictionary<string, int>());

                    database[contest].Add(userName, points);
                    CalculateIndividualStandings(individualStandings, userName, points);
                }
                else
                {
                    if (!database[contest].ContainsKey(userName))
                    {
                        database[contest].Add(userName, points);
                        CalculateIndividualStandings(individualStandings, userName, points);
                    }
                    else
                    {
                        if (points > database[contest][userName])
                        {
                            database[contest][userName] = points;

                            if (!individualStandings.ContainsKey(userName))
                            {
                                individualStandings.Add(userName, points);
                            }
                            else if (points > individualStandings[userName])
                            {
                                individualStandings[userName] = points;
                            }
                        }
                    }
                }
            }

            int positionCounter = 0;
            foreach (var item in database)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count()} participants");

                foreach (var subjects in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    positionCounter++;
                    Console.WriteLine($"{positionCounter}. {subjects.Key} <::> {subjects.Value}");
                }

                positionCounter = 0;
            }

            Console.WriteLine("Individual standings: ");
            foreach (var item in individualStandings.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                positionCounter++;
                Console.WriteLine($"{positionCounter}. {item.Key} -> {item.Value}");
            }
        }

        private static void CalculateIndividualStandings(Dictionary<string, int> individualStandings, string userName, int points)
        {
            if (!individualStandings.ContainsKey(userName))
            {
                individualStandings.Add(userName, points);
            }
            else
            {
                individualStandings[userName] += points;
            }
        }
    }
}