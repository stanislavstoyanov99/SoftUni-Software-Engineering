namespace PetStore.Services.Implementations
{
    using System;
    using System.Linq;

    using Utilities;
    using Models.Food;

    using Data;
    using Data.Models;
    using Data.Models.Enumerations;

    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext data;
        private readonly IUserService userService;

        public FoodService(PetStoreDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }

        public void BuyFromDistributor(string name, double weight, decimal price, double profit,
            DateTime expirationDate, int brandId, int categoryId)
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

            var food = new Food()
            {
                Name = name,
                Weight = weight,
                DistributorPrice = price,
                Price = price + (price * (decimal)profit),
                ExpirationDate = expirationDate,
                BrandId = brandId,
                CategoryId = categoryId
            };

            this.data.Food.Add(food);
            this.data.SaveChanges();
        }

        public void BuyFromDistributor(AddingFoodServiceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException(ExceptionMessages.InvalidName);
            }

            if (model.Profit < 0 || model.Profit > 5)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProfitValue);
            }

            var food = new Food()
            {
                Name = model.Name,
                Weight = model.Weight,
                DistributorPrice = model.Price,
                Price = model.Price + (model.Price * (decimal)model.Profit),
                BrandId = model.BrandId,
                CategoryId = model.CategoryId
            };

            this.data.Food.Add(food);
            this.data.SaveChanges();
        }

        public void SellFoodToUser(int foodId, int userId)
        {
            if (!this.Exists(foodId))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.FoodDoesNotExist, foodId));
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

            var foodOrder = new FoodOrder()
            {
                FoodId = foodId,
                Order = order
            };

            this.data.Orders.Add(order);
            this.data.FoodOrders.Add(foodOrder);

            this.data.SaveChanges();
        }

        public bool Exists(int foodId)
        {
            return this.data.Food.Any(f => f.Id == foodId);
        }
    }
}
