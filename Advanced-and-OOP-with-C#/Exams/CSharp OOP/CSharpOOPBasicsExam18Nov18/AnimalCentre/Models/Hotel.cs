namespace AnimalCentre.Models
{
    using System;
    using System.Collections.Generic;

    using AnimalCentre.Models.Contracts;
    using AnimalCentre.Utilities.Messages;

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
                throw new InvalidOperationException(ExceptionMessages.InvalidHotelCapacity);
            }

            if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AnimalAlreadyExists,
                    animal.Name));
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AnimalDoesNotExist,
                    animalName));
            }

            this.animals[animalName].Owner = owner;
            this.animals[animalName].IsAdopt = true;

            this.animals.Remove(animalName);
        }
    }
}
