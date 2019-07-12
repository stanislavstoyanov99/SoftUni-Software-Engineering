using System;
using System.Linq;
using System.Collections.Generic;

using _06BirthdayCelebrations.Extentions;
using _06BirthdayCelebrations.Interfaces;
using _06BirthdayCelebrations.Models;

namespace _06BirthdayCelebrations.Core
{
    public class Engine
    {
        private readonly List<IBirthdable> citizensAndPets;
        private readonly List<IIdentifiable> robots;

        public Engine()
        {
            this.citizensAndPets = new List<IBirthdable>();
            this.robots = new List<IIdentifiable>();
        }

        public IReadOnlyCollection<IBirthdable> CitizensAndPets
        {
            get
            {
                return this.citizensAndPets;
            }
        }

        public IReadOnlyCollection<IIdentifiable> Robots
        {
            get
            {
                return this.robots;
            }
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];

                if (type == "Citizen")
                {
                    CreateCitizen(tokens);
                }
                else if (type == "Robot")
                {
                    CreateRobot(tokens);
                }
                else if (type == "Pet")
                {
                    CreatePet(tokens);
                }
            }

            string targetYear = Console.ReadLine();

            var birthdates = this.CitizensAndPets
                .Where(x => x.Birthdate.EndsWith(targetYear))
                .Select(x => x.Birthdate)
                .ToList();

            Console.WriteLine(birthdates.PrintAll());
        }

        private void CreatePet(string[] tokens)
        {
            string petName = tokens[1];
            string petBirthdate = tokens[2];

            IBirthdable pet = new Pet(petName, petBirthdate);
            this.citizensAndPets.Add(pet);
        }

        private void CreateRobot(string[] tokens)
        {
            string model = tokens[1];
            string robotId = tokens[2];

            IIdentifiable robot = new Robot(model, robotId);
            this.robots.Add(robot);
        }

        private void CreateCitizen(string[] tokens)
        {
            string citizenName = tokens[1];
            int citizenAge = int.Parse(tokens[2]);
            string citizenId = tokens[3];
            string citizenBirthdate = tokens[4];

            IBirthdable citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
            this.citizensAndPets.Add(citizen);
        }
    }
}
