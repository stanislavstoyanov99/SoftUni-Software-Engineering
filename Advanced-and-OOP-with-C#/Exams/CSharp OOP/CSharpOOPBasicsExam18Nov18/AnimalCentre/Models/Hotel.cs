﻿namespace AnimalCentre.Models
{
    using System;
    using System.Collections.Generic;

    using AnimalCentre.Models.Contracts;

    public class Hotel : IHotel
    {
        private const int Capacity = 10;

        private readonly Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;

        public void Accommodate(IAnimal animal)
        {
            if (this.animals.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            this.animals[animalName].Owner = owner;
            this.animals[animalName].IsAdopt = true;

            this.animals.Remove(animalName);
        }
    }
}
