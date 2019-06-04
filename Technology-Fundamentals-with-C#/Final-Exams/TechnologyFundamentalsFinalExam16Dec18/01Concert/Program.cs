using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();
            var membersOfBand = new Dictionary<string, List<string>>();

            int totalTime = 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "start of concert")
            {
                string[] tokens = input.Split("; ");
                string command = tokens[0];
                string bandName = tokens[1];

                if (command == "Play")
                {
                    int time = int.Parse(tokens[2]);
                    totalTime += time;

                    if (!dictionary.ContainsKey(bandName))
                    {
                        dictionary.Add(bandName, time);
                    }
                    else
                    {
                        dictionary[bandName] += time;
                    }
                }
                else
                {
                    string allMembers = tokens[2];
                    string[] memberAsArray = allMembers.Split(", ");

                    foreach (var member in memberAsArray)
                    {
                        if (!membersOfBand.ContainsKey(bandName))
                        {
                            membersOfBand.Add(bandName, new List<string>() { member });
                        }
                        else if (membersOfBand[bandName].Contains(member))
                        {
                            membersOfBand[bandName].Add(member);
                        }
                    }
                }
            }

            string bandNameToPrint = Console.ReadLine();

            Console.WriteLine($"Total time: {totalTime}");
            foreach (var kvp in dictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine($"{bandNameToPrint}");

            var filteredNames = membersOfBand.Where(m => m.Key == bandNameToPrint).ToList();
            foreach (var item in filteredNames)
            {
                Console.WriteLine($"=> {string.Join(Environment.NewLine + "=> ", item.Value)}");
            }
        }
    }
}
