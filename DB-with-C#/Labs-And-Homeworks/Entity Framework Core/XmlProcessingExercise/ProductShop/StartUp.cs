namespace ProductShop
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    using AutoMapper;

    using ProductShop.Data;
    using ProductShop.Models;
    using ProductShop.Dtos.Import;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new ProductShopContext();

            Mapper.Initialize(cfg => cfg.AddProfile(new ProductShopProfile()));

            string users = File.ReadAllText("./../../../Datasets/users.xml");
            string products = File.ReadAllText("./../../../Datasets/products.xml");

            //Console.WriteLine(ImportUsers(db, users));
            Console.WriteLine(ImportProducts(db, products));
        }

        // Problem 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(ImportUser[]), rootAttribute);

            var usersDto = (ImportUser[])xmlSerializer.Deserialize(new StringReader(inputXml));

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

            var productsDto = (ImportProduct[])xmlSerializer.Deserialize(new StringReader(inputXml));

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                context.Products.Add(product);
            }

            int productsCount = context.SaveChanges();

            return $"Successfully imported {productsCount}";
        }

    }
}