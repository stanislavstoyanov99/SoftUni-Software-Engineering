using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine().ToLower();
            string town = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());

            double totalPrice = 0.0;

            if (town == "sofia")
            {
                if (product == "coffee")
                {
                    totalPrice = 0.50 * quantity;
                }
                else if (product == "water")
                {
                    totalPrice = 0.80 * quantity;
                }
                else if (product == "beer")
                {
                    totalPrice = 1.20 * quantity;
                }
                else if (product == "sweets")
                {
                    totalPrice = 1.45 * quantity;
                }
                else if (product == "peanuts")
                {
                    totalPrice = 1.60 * quantity;
                }
            }
            else if (town == "plovdiv")
            {
                if (product == "coffee")
                {
                    totalPrice = 0.40 * quantity;
                }
                else if (product == "water")
                {
                    totalPrice = 0.70 * quantity;
                }
                else if (product == "beer")
                {
                    totalPrice = 1.15 * quantity;
                }
                else if (product == "sweets")
                {
                    totalPrice = 1.30 * quantity;
                }
                else if (product == "peanuts")
                {
                    totalPrice = 1.50 * quantity;
                }
            }
            else if (town == "varna")
            {
                if (product == "coffee")
                {
                    totalPrice = 0.45 * quantity;
                }
                else if (product == "water")
                {
                    totalPrice = 0.70 * quantity;
                }
                else if (product == "beer")
                {
                    totalPrice = 1.10 * quantity;
                }
                else if (product == "sweets")
                {
                    totalPrice = 1.35 * quantity;
                }
                else if (product == "peanuts")
                {
                    totalPrice = 1.55 * quantity;
                }
            }
            Console.WriteLine(totalPrice);
        }
    }
}
