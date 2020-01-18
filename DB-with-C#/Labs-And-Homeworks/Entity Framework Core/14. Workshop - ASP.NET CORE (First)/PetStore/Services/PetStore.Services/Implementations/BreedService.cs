namespace PetStore.Services.Implementations
{
    using System;
    using System.Linq;

    using Utilities;

    using PetStore.Data;
    using PetStore.Data.Models;

    public class BreedService : IBreedService
    {
        private readonly PetStoreDbContext data;

        public BreedService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public int Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.InvalidName);
            }

            var breed = new Breed()
            {
                Name = name
            };

            this.data.Breeds.Add(breed);
            this.data.SaveChanges();

            return breed.Id;
        }

        public bool Exists(int breedId)
        {
            return this.data.Breeds.Any(b => b.Id == breedId);
        }
    }
}
