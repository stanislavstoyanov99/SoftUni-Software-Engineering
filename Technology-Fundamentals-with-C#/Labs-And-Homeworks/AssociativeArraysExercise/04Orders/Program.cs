using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            // make dictionary with string and double[]
            var products = new Dictionary<string, double[]>();
            //var products = new Dictionary<string, List<double>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] productInfo = input.Split();
                string productName = productInfo[0];
                double productPrice = double.Parse(productInfo[1]);
                double productQuantity = double.Parse(productInfo[2]);

                // if the dictionary does not have the product name, we create new array double[] for values
                if (!products.ContainsKey(productName))
                {
                    products[productName] = new double[2];
                    //products[productName] = new List<double>() { 0, 0 };
                }

                products[productName][0] = productPrice; // we set the zero index for the product price
                products[productName][1] += productQuantity; // we set the first index for the product quantity
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):F2}");
            }
        }
    }
}
