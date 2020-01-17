namespace PetStore.Services.Implementations
{
    using System;

    using Utilities;
    using Models.Toy;

    using PetStore.Data;
    using PetStore.Data.Models;

    public class ToyService : IToyService
    {
        private readonly PetStoreDbContext data;

        public ToyService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void BuyFromDistributor(string name, string description, decimal distributorPrice,
            double profit, int brandId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidName));
            }

            // Profit should be in range 0-500%
            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidProfitValue));
            }

            var toy = new Toy()
            {
                Name = name,
                Desciption = description,
                DistributorPrice = distributorPrice,
                Price = distributorPrice + (distributorPrice * (decimal)profit),
                BrandId = brandId,
                CategoryId = categoryId
            };

            this.data.Toys.Add(toy);
            this.data.SaveChanges();
        }

        public void BuyFromDistributor(AddingToyServiceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidName));
            }

            if (model.Profit < 0 || model.Profit > 5)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidProfitValue));
            }

            var toy = new Toy()
            {
                Name = model.Name,
                Desciption = model.Description,
                DistributorPrice = model.Price,
                Price = model.Price + (model.Price * (decimal)model.Profit),
                BrandId = model.BrandId,
                CategoryId = model.CategoryId
            };

            this.data.Toys.Add(toy);
            this.data.SaveChanges();
        }
    }
}
