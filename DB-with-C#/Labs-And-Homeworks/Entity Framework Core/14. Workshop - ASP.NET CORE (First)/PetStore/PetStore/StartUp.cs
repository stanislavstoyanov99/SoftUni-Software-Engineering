namespace PetStore
{
    using System;

    using Data;
    using Data.Models.Enumerations;

    using Services.Implementations;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var petStoreDbContext = new PetStoreDbContext();

            var breedService = new BreedService(petStoreDbContext);
            var categoryService = new CategoryService(petStoreDbContext);
            var userService = new UserService(petStoreDbContext);

            var petService = new PetService(petStoreDbContext, breedService, categoryService, userService);
            petService.BuyPet(Gender.Male, DateTime.Now, 0m, null, 1, 1);
            petService.SellPet(1, 1);
        }
    }
}
