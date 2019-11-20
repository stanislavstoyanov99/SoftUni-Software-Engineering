namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using ProductShop.Data;
    using ProductShop.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new ProductShopContext();

            //string inputJson = File.ReadAllText(@"./../../../Datasets/categories-products.json");

            Console.WriteLine(GetUsersWithProducts(db));
        }

        // Problem 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);

            int usersCount = context.SaveChanges();

            return $"Successfully imported {usersCount}";
        }

        // Problem 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);

            int productsCount = context.SaveChanges();

            return $"Successfully imported {productsCount}";
        }

        // Problem 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);

            int categoriesCount = context.SaveChanges();

            return $"Successfully imported {categoriesCount}";
        }

        // Problem 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);

            int categoryProductsCount = context.SaveChanges();

            return $"Successfully imported {categoryProductsCount}";
        }

        // Problem 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToList();

            // Second solution
            /*DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(productsInRange, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });*/

            string jsonExport = JsonConvert.SerializeObject(productsInRange, new JsonSerializerSettings()
            { 
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });

            return jsonExport;
        }

        // Problem 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(u => u.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(u => u.Buyer != null)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            string jsonExport = JsonConvert.SerializeObject(users, new JsonSerializerSettings() 
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });

            return jsonExport;
        }

        // Problem 07. Export Categories By Products Count 
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = $"{c.CategoryProducts.Average(c => c.Product.Price):F2}",
                    TotalRevenue = $"{c.CategoryProducts.Sum(c => c.Product.Price):F2}"
                })
                .OrderByDescending(c => c.ProductsCount)
                .ToList();

            string jsonExport = JsonConvert.SerializeObject(categories, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });

            return jsonExport;
        }

        //Problem 08. Export Users and Products 
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .ToList()
                    }
                })
                .ToList();

            var resultView = new
            {
                UsersCount = users.Count,
                Users = users
            };

            string jsonExport = JsonConvert.SerializeObject(resultView, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return jsonExport;
        }
    }
}