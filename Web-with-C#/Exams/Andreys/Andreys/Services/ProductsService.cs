namespace Andreys.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Data;
    using Models;
    using ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void Add(string name, string description, string imageUrl, string category, string gender, decimal price, string userId)
        {
            Enum.TryParse(category, out Category categoryEnum);
            Enum.TryParse(gender, out Gender genderEnum);

            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Category = categoryEnum,
                Gender = genderEnum,
                Price = price,
                UserId = userId
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = this.db.Products.Find(id);
            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }

        public DetailsViewModel GetDetails(int id)
        {
            var viewModel = this.db.Products
                .Where(x => x.Id == id)
                .Select(x => new DetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Gender = x.Gender.ToString(),
                    Category = x.Category.ToString(),
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Price = x.Price
                })
                .FirstOrDefault();

            return viewModel;
        }

        public IEnumerable<InfoViewModel> ListAllProducts(string userId)
        {
            var allAlbums = this.db.Products
                .Where(x => x.UserId == userId)
                .Select(x => new InfoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ImageUrl = x.ImageUrl             
                })
                .ToList();

            return allAlbums;
        }
    }
}
