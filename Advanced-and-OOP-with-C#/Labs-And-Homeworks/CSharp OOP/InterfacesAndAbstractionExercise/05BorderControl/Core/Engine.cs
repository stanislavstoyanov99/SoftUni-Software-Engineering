using System;
using System.Linq;
using System.Collections.Generic;

using _05BorderControl.Extentions;
using _05BorderControl.Interfaces;
using _05BorderControl.Models;

namespace _05BorderControl.Core
{
    public class Engine
    {
        private readonly List<IIdentifiable> citizensAndRobots;

        public Engine()
        {
            this.citizensAndRobots = new List<IIdentifiable>();
        }

        public IReadOnlyCollection<IIdentifiable> CitizensAndRobots
        {
            get
            {
                return this.citizensAndRobots;
            }
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    CreateCitizen(tokens);
                }
                else
                {
                    CreateRobot(tokens);
                }
            }

            string lastDigits = Console.ReadLine();

            var fakeIds = CitizensAndRobots
                .Where(c => c.Id.EndsWith(lastDigits))
                .Select(c => c.Id)
                .ToList();

            Console.WriteLine(fakeIds.PrintAll());
        }

        private void CreateRobot(string[] tokens)
        {
            string robotName = tokens[0];
            string robotId = tokens[1];

            IIdentifiable robot = new Robot(robotName, robotId);
            citizensAndRobots.Add(robot);
        }

        private void CreateCitizen(string[] tokens)
        {
            string citizenName = tokens[0];
            int citizenAge = int.Parse(tokens[1]);
            string citizenId = tokens[2];

            IIdentifiable citizen = new Citizen(citizenName, citizenAge, citizenId);
            citizensAndRobots.Add(citizen);
        }
    }
}
