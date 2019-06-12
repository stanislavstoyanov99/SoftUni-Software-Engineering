using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;
            List<Trainer> trainers = new List<Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                var trainer = trainers.First(t => t.Name == trainerName);
                trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }

            string secondInput = string.Empty;
            while ((secondInput = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(t => t.Element == secondInput))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(t => t.Health -= 10);
                    }

                    trainer.Pokemons = trainer.Pokemons
                        .Where(p => p.Health > 0)
                        .ToList();
                }
            }

            var filteredTrainers = trainers
                .OrderByDescending(t => t.NumberOfBadges)
                .ToList();

            foreach (var trainer in filteredTrainers)
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
