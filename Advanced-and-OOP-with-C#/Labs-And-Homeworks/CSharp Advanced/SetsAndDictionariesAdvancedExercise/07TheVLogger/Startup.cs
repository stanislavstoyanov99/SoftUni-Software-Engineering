using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TheVLogger
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var vloggerCollection = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains("joined"))
                {
                    string vloggerName = tokens[0];

                    if (!vloggerCollection.ContainsKey(vloggerName))
                    {
                        vloggerCollection.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        vloggerCollection[vloggerName].Add("followings", new HashSet<string>());
                        vloggerCollection[vloggerName].Add("followers", new HashSet<string>());
                    }
                }
                else if (input.Contains("followed"))
                {
                    string firstVlogger = tokens[0];
                    string secondVlogger = tokens[2];

                    if (!vloggerCollection.ContainsKey(firstVlogger) 
                        || !vloggerCollection.ContainsKey(secondVlogger) 
                        || firstVlogger == secondVlogger)
                    {
                        continue;
                    }

                    vloggerCollection[firstVlogger]["followings"].Add(secondVlogger);
                    vloggerCollection[secondVlogger]["followers"].Add(firstVlogger);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggerCollection.Count} vloggers in its logs.");

            int count = 1;
            var sortedCollection = vloggerCollection
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["followings"].Count)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var (username, value) in sortedCollection)
            {
                int followersCount = sortedCollection[username]["followers"].Count;
                int followingsCount = sortedCollection[username]["followings"].Count;

                Console.WriteLine($"{count}. {username} : {followersCount} followers, {followingsCount} following");

                if (count == 1)
                {
                    var followersCollection = value["followers"].OrderBy(x => x).ToList();

                    foreach (var follower in followersCollection)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }
    }
}
