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

            // BrandService brandService = new BrandService(petStoreDbContext);
            // brandService.Create("Purrina");

            // var brandWithToys = brandService.FindByIdWithToys(1);
            // FoodService foodService = new FoodService(petStoreDbContext);
            // foodService.BuyFromDistributor("Whiskas 2", 0.350, 1.1m, 0.2, DateTime.Now, 2, 1);

            ToyService toyService = new ToyService(petStoreDbContext);
            toyService.BuyFromDistributor("Ball", null, 3.50m, 0.3, 1, 1);
        }
    }
}
