namespace PetStore
{
    using System;

    using Data;
    using Services.Implementations;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var petStoreDbContext = new PetStoreDbContext();

            BrandService brandService = new BrandService(petStoreDbContext);
            // brandService.Create("Purrina");

            var brandWithToys = brandService.FindByIdWithToys(1);
        }
    }
}
