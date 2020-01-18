namespace PetStore.Services.Implementations
{
    using System;
    using System.Linq;

    using Utilities;
    using Models.Toy;

    using Data;
    using Data.Models;
    using Data.Models.Enumerations;

    public class ToyService : IToyService
    {
        private readonly PetStoreDbContext data;
        private readonly IUserService userService;

        public ToyService(PetStoreDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }

        public void BuyFromDistributor(string name, string description, decimal distributorPrice,
            double profit, int brandId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.InvalidName);
            }

            // Profit should be in range 0-500%
            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProfitValue);
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
                throw new ArgumentException(ExceptionMessages.InvalidName);
            }

            if (model.Profit < 0 || model.Profit > 5)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProfitValue);
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

        public void SellToyToUser(int toyId, int userId)
        {
            if (!this.Exists(toyId))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ToyDoesNotExist, toyId));
            }

            if (!this.userService.Exists(userId))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.UserDoesNotExist, userId));
            }

            var order = new Order()
            {
                PurchaseDate = DateTime.Now,
                Status = OrderStatus.Done,
                UserId = userId
            };

            var toyOrder = new ToyOrder()
            {
                Order = order,
                ToyId = toyId
            };

            this.data.Orders.Add(order);
            this.data.ToyOrders.Add(toyOrder);
            this.data.SaveChanges();
        }

        public bool Exists(int toyId)
        {
            return this.data.Toys.Any(t => t.Id == toyId);
        }
    }
}
