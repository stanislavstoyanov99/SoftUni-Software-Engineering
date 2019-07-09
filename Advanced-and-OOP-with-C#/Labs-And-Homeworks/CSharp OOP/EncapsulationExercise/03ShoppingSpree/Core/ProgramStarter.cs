using System;
using System.Linq;
using System.Collections.Generic;

using ShoppingSpree.Models;
using _03ShoppingSpree.Extensions;

namespace ShoppingSpree.Core
{
    public class ProgramStarter
    {
        private IList<Person> people;
        private IList<Product> products;

        public ProgramStarter()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void RunProgram()
        {
            try
            {
                ReadPersonData();
                ReadProductData();
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
                Environment.Exit(0);
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = tokens[0];
                    string productName = tokens[1];

                    ProductProcessing(personName, productName);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (NullReferenceException ne)
                {
                    Console.WriteLine(ne.Message);
                }
            }

            Console.WriteLine(people.PrintAll());
        }

        private void ProductProcessing(string personName, string productName)
        {
            Person person = this.people
                .FirstOrDefault(p => p.Name == personName);
            Product product = this.products
                .FirstOrDefault(p => p.Name == productName);

            if (person != null && product != null)
            {
                person.BuyProduct(product);
                Console.WriteLine($"{personName} bought {productName}");
            }
        }

        private void ReadProductData()
        {
            string[] productTokens = Console.ReadLine()
                                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productTokens.Length; i++)
            {
                string[] productInfo = productTokens[i].Split("=");
                string productName = productInfo[0];
                decimal productPrice = decimal.Parse(productInfo[1]);

                Product product = new Product(productName, productPrice);
                products.Add(product);
            }
        }

        private void ReadPersonData()
        {
            string[] personTokens = Console.ReadLine()
                                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < personTokens.Length; i++)
            {
                string[] personInfo = personTokens[i].Split("=");
                string personName = personInfo[0];
                decimal personMoney = decimal.Parse(personInfo[1]);

                Person person = new Person(personName, personMoney);
                people.Add(person);
            }
        }
    }
}
