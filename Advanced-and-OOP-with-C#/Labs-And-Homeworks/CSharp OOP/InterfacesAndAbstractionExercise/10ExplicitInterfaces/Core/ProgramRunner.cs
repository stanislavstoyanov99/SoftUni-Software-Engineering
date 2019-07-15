using System;
using System.Collections.Generic;

using _10ExplicitInterfaces.Exceptions;
using _10ExplicitInterfaces.Factories;
using _10ExplicitInterfaces.Interfaces;
using _10ExplicitInterfaces.Models;

namespace _10ExplicitInterfaces.Core
{
    public class ProgramRunner
    {
        private readonly List<Citizen> citizens;
        private readonly PersonFactory personFactory;

        public ProgramRunner()
        {
            this.citizens = new List<Citizen>();
            this.personFactory = new PersonFactory();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenInformation = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Citizen citizen = this.personFactory.CreateCitizen(citizenInformation);
                this.citizens.Add(citizen);
            }

            try
            {
                PrintPeople();
            }
            catch (InexistentPersonTypeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PrintPeople()
        {
            foreach (var person in this.citizens)
            {
                if (person is IPerson castedPerson)
                {
                    Console.WriteLine(castedPerson.GetName());
                }
                else
                {
                    throw new InexistentPersonTypeException();
                }

                if (person is IResident castedResident)
                {
                    Console.WriteLine(castedResident.GetName());
                }
                else
                {
                    throw new InexistentPersonTypeException();
                }
            }
        }
    }
}
