using System;
using System.Linq;

using AnimalCentre.Models;
using AnimalCentre.Core.Contracts;
using AnimalCentre.Core.Factories;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre.Core
{
    public class AnimalCentre : IAnimalCentre
    {
        private readonly AnimalFactory animalFactory;

        private readonly Hotel hotel;
        private readonly Chip chip;
        private readonly Vaccinate vaccinate;
        private readonly Fitness fitness;
        private readonly DentalCare dentalCare;
        private readonly Play play;
        private readonly NailTrim nailTrim;

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory();

            this.hotel = new Hotel();
            this.chip = new Chip();
            this.vaccinate = new Vaccinate();
            this.fitness = new Fitness();
            this.dentalCare = new DentalCare();
            this.play = new Play();
            this.nailTrim = new NailTrim();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            this.hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = this.hotel.Animals
                .First(a => a.Key == name)
                .Value;

            this.chip.DoService(animal, procedureTime);

            return $"{animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = this.hotel.Animals
                .First(a => a.Key == name)
                .Value;

            this.vaccinate.DoService(animal, procedureTime);

            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = this.hotel.Animals
                .First(a => a.Key == name)
                .Value;

            this.fitness.DoService(animal, procedureTime);

            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = this.hotel.Animals
                .First(a => a.Key == name)
                .Value;

            this.play.DoService(animal, procedureTime);

            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = this.hotel.Animals
                .First(a => a.Key == name)
                .Value;

            this.dentalCare.DoService(animal, procedureTime);

            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = this.hotel.Animals
                .First(a => a.Key == name)
                .Value;

            this.nailTrim.DoService(animal, procedureTime);

            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal animal = this.hotel.Animals
                .FirstOrDefault(a => a.Key == animalName)
                .Value;

            if (animal == null)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            this.hotel.Adopt(animal.Name, owner);

            string result = string.Empty;

            if (animal.IsChipped)
            {
                result = $"{owner} adopted animal with chip";
            }
            else
            {
                result = $"{owner} adopted animal without chip";
            }

            return result;
        }

        public string History(string type)
        {
            string result = string.Empty;

            if (type == "Chip")
            {
                result = this.chip.History();
            }
            else if (type == "DentalCare")
            {
                result = this.dentalCare.History();
            }
            else if (type == "Fitness")
            {
                result = this.fitness.History();
            }
            else if (type == "NailTrim")
            {
                result = this.nailTrim.History();
            }
            else if (type == "Play")
            {
                result = this.play.History();
            }
            else if (type == "Vaccinate")
            {
                result = this.vaccinate.History();
            }

            return result;
        }
    }
}
