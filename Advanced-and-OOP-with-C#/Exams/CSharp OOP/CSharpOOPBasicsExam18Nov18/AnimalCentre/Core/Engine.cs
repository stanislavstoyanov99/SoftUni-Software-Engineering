using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using AnimalCentre.Core.Contracts;

namespace AnimalCentre.Core
{
    public class Engine : IEngine
    {
        private readonly AnimalCentre animalCentre;
        private readonly Dictionary<string, List<string>> adoptedAnimals;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
            this.adoptedAnimals = new Dictionary<string, List<string>>();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string commandName = commandArgs[0];
                string result = string.Empty;

                try
                {
                    switch (commandName)
                    {
                        case "RegisterAnimal":
                            string animalType = commandArgs[1];
                            string animalName = commandArgs[2];
                            int energy = int.Parse(commandArgs[3]);
                            int happiness = int.Parse(commandArgs[4]);
                            int procedureTime = int.Parse(commandArgs[5]);

                            result = this.animalCentre
                                .RegisterAnimal(animalType, animalName, energy, happiness, procedureTime);

                            Console.WriteLine(result);
                            break;
                        case "Chip":
                            string nameToChip = commandArgs[1];
                            int procedureChipTime = int.Parse(commandArgs[2]);

                            result = this.animalCentre
                                .Chip(nameToChip, procedureChipTime);

                            Console.WriteLine(result);
                            break;

                        case "Vaccinate":
                            string nameToVaccinate = commandArgs[1];
                            int procedureVaccinateTime = int.Parse(commandArgs[2]);

                            result = this.animalCentre
                                .Vaccinate(nameToVaccinate, procedureVaccinateTime);

                            Console.WriteLine(result);
                            break;
                        case "Fitness":
                            string nameToFitness = commandArgs[1];
                            int procedureFitnessTime = int.Parse(commandArgs[2]);

                            result = this.animalCentre
                                .Fitness(nameToFitness, procedureFitnessTime);

                            Console.WriteLine(result);
                            break;
                        case "Play":
                            string nameToPlay = commandArgs[1];
                            int procedurePlayTime = int.Parse(commandArgs[2]);

                            result = this.animalCentre
                                .Play(nameToPlay, procedurePlayTime);

                            Console.WriteLine(result);
                            break;
                        case "DentalCare":
                            string nameToDentalCare = commandArgs[1];
                            int procedureDentalCareTime = int.Parse(commandArgs[2]);

                            result = this.animalCentre
                                .DentalCare(nameToDentalCare, procedureDentalCareTime);

                            Console.WriteLine(result);
                            break;
                        case "NailTrim":
                            string nameToNailTrim = commandArgs[1];
                            int procedureNailTrimTime = int.Parse(commandArgs[2]);

                            result = this.animalCentre
                                .NailTrim(nameToNailTrim, procedureNailTrimTime);

                            Console.WriteLine(result);
                            break;
                        case "Adopt":
                            string nameToAdopt = commandArgs[1];
                            string owner = commandArgs[2];

                            result = this.animalCentre
                                .Adopt(nameToAdopt, owner);

                            if (!this.adoptedAnimals.ContainsKey(owner))
                            {
                                this.adoptedAnimals[owner] = new List<string>
                                {
                                    nameToAdopt
                                };
                            }
                            else
                            {
                                this.adoptedAnimals[owner].Add(nameToAdopt);
                            }
                            
                            Console.WriteLine(result);
                            break;
                        case "History":
                            string procedureType = commandArgs[1];

                            result = this.animalCentre
                                .History(procedureType);

                            Console.WriteLine(result);
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"InvalidOperationException: {ioe.Message}");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine($"ArgumentException: {ae.Message}");
                }
            }

            StringBuilder sb = new StringBuilder();

            if (this.adoptedAnimals.Count > 0)
            {
                foreach (var kvp in this.adoptedAnimals.OrderBy(a => a.Key))
                {
                    sb.AppendLine($"--Owner: {kvp.Key}")
                        .AppendLine($"    - Adopted animals: {string.Join(" ", kvp.Value)}");
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
