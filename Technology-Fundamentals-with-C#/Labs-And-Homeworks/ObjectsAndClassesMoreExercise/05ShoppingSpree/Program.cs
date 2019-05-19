using System;
using System.Collections.Generic;

namespace _05ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInput = Console.ReadLine().Split(';');
            foreach (var person in peopleInput)
            {
                string name = person.Split('=')[0];
                double money = double.Parse(person.Split('=')[1]);
                people.Add(new Person(name, money));
            }

            string[] productsInput = Console.ReadLine().Split(';');
            foreach (var product in productsInput)
            {
                string name = product.Split('=')[0];
                double price = double.Parse(product.Split('=')[1]);
                products.Add(new Product(name, price));
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(" ");
                string personName = tokens[0];
                string productName = tokens[1];

                people.Find(p => p.Name == personName).BuyProduct(products.Find(p => p.Name == productName));
            }

            foreach (var person in people)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public double Money { get; set; }
        public List<string> BagOfProducts { get; set; } = new List<string>();

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
        }

        public void BuyProduct(Product productToBuy)
        {
            if (Money >= productToBuy.Price)
            {
                BagOfProducts.Add(productToBuy.Name);
                Money -= productToBuy.Price;
                Console.WriteLine($"{Name} bought {productToBuy.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {productToBuy.Name}");
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string productName, double price)
        {
            Name = productName;
            Price = price;
        }
    }
}
