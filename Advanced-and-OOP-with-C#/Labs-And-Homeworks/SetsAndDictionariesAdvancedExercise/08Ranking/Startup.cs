using System;
using System.Collections.Generic;
using System.Linq;

namespace _08Ranking
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var submissions = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = input.Split(":");
                string contestName = tokens[0];
                string contestPassword = tokens[1];

                contests.Add(contestName, contestPassword);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = input.Split("=>");
                string contestName = tokens[0];
                string contestPassword = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!contests.ContainsKey(contestName) || contests[contestName] != contestPassword)
                {
                    continue;
                }

                if (!submissions.ContainsKey(username))
                {
                    submissions.Add(username, new Dictionary<string, int>());
                }

                if (!submissions[username].ContainsKey(contestName))
                {
                    submissions[username].Add(contestName, points);
                }

                if (submissions[username][contestName] < points)
                {
                    submissions[username][contestName] = points;
                }
            }

            var bestCandidate = submissions
                .OrderByDescending(x => x.Value.Values.Sum())
                .FirstOrDefault();

            string bestCandidateName = bestCandidate.Key;
            int bestCandidatePoints = bestCandidate.Value.Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidateName} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var (key, value) in submissions.OrderBy(x => x.Key))
            {
                Console.WriteLine(key);

                foreach (var (contestName, points) in value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestName} -> {points}");
                }
            }
        }
    }
}
