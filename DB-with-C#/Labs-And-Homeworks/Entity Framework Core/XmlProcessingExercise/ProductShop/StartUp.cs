namespace ProductShop
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    using AutoMapper;

    using ProductShop.Data;
    using ProductShop.Models;
    using ProductShop.Dtos.Import;
    using ProductShop.Dtos.Export;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new ProductShopContext();

            //Mapper.Initialize(cfg => cfg.AddProfile(new ProductShopProfile()));

            //string users = File.ReadAllText("./../../../Datasets/users.xml");
            //string products = File.ReadAllText("./../../../Datasets/products.xml");
            //string categories = File.ReadAllText("./../../../Datasets/categories.xml");
            //string categoriesAndProducts = File.ReadAllText("./../../../Datasets/categories-products.xml");

            //Console.WriteLine(ImportUsers(db, users));
            //Console.WriteLine(ImportProducts(db, products));
            //Console.WriteLine(ImportCategories(db, categories));
            //Console.WriteLine(ImportCategoryProducts(db, categoriesAndProducts));

            Console.WriteLine(GetUsersWithProducts(db));
        }

        // Problem 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(ImportUser[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);
            ImportUser[] usersDto = (ImportUser[])xmlSerializer.Deserialize(stringReader);

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                context.Users.Add(user);
            }

            int usersCount = context.SaveChanges();

            return $"Successfully imported {usersCount}";
        }

        // Problem 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Products");
            var xmlSerializer = new XmlSerializer(typeof(ImportProduct[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);
            ImportProduct[] productsDto = (ImportProduct[])xmlSerializer.Deserialize(stringReader);

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                context.Products.Add(product);
            }

            int productsCount = context.SaveChanges();

            return $"Successfully imported {productsCount}";
        }

        // Problem 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Categories");
            var xmlSerializer = new XmlSerializer(typeof(ImportCategory[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);
            ImportCategory[] categoriesDto = ((ImportCategory[])xmlSerializer.Deserialize(stringReader))
                .Where(c => c.Name != null)
                .ToArray();

            foreach (var categoryDto in categoriesDto)
            {
                var category = Mapper.Map<Category>(categoryDto);

                context.Categories.Add(category);
            }

            int categoriesCount = context.SaveChanges();

            return $"Successfully imported {categoriesCount}";
        }

        // Problem 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("CategoryProducts");
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProduct[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);
            var categoryProducts = (ImportCategoryProduct[])xmlSerializer.Deserialize(stringReader);

            foreach (var categoryDto in categoryProducts)
            {
                var category = context.Categories
                    .FirstOrDefault(c => c.Id == categoryDto.CategoryId);
                var product = context.Products
                    .FirstOrDefault(p => p.Id == categoryDto.ProductId);

                if (category != null && product != null)
                {
                    var categoryProduct = Mapper.Map<CategoryProduct>(categoryDto);

                    context.CategoryProducts.Add(categoryProduct);
                }
            }

            int categoryProductsCount = context.SaveChanges();

            return $"Successfully imported {categoryProductsCount}";
        }

        // Problem 05. Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .Take(10)
                .ToArray();

            var rootAttribute = new XmlRootAttribute("Products");
            var xmlSerializer = new XmlSerializer(typeof(ProductInRangeDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();
            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, productsInRange, namespaces);

            return sb.ToString().TrimEnd();
        }

        // Problem 06. Export Sold Products 
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new UserSoldProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductsSold = u.ProductsSold
                    .Select(p => new ProductInfoDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var rootAttribute = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(UserSoldProductDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();
            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, users, namespaces);

            return sb.ToString().TrimEnd();
        }

        // Problem 07. Export Categories By Products Count 
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context.Categories
                .Select(c => new CategoryDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var rootAttribute = new XmlRootAttribute("Categories");
            var xmlSerializer = new XmlSerializer(typeof(CategoryDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();
            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, categoriesByProductsCount, namespaces);

            return sb.ToString().TrimEnd();
        }

        // Problem 08. Export Users and Products 
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(u => new UserInfoDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    ProductsSold = new SoldProductsDto
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .OrderByDescending(p => p.Price)
                            .Select(p => new ProductInfoDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var usersAndProducts = new UsersOutputDto
            { 
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = usersWithProducts
            };

            var rootAttribute = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(UsersOutputDto), rootAttribute);

            StringBuilder sb = new StringBuilder();
            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, usersAndProducts, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}