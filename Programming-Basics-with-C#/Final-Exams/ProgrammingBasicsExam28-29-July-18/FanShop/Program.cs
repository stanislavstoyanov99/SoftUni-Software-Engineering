using System;

namespace FanShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int items = int.Parse(Console.ReadLine());

            int priceOfItem = 0;
            int leftMoney = 0;
            int neededMoney = 0;
            int totalSum = 0;

            for (int i = 1; i <= items; i++)
            {
                string text = Console.ReadLine();
                if (text == "hoodie")
                {
                    priceOfItem += 30;
                }
                else if (text == "keychain")
                {
                    priceOfItem += 4;
                }
                else if (text == "T-shirt")
                {
                    priceOfItem += 20;
                }
                else if (text == "flag")
                {
                    priceOfItem += 15;
                }
                else if (text == "sticker")
                {
                    priceOfItem += 1;
                }
                totalSum = priceOfItem;
                leftMoney = Math.Abs(budget - totalSum);
                neededMoney = Math.Abs(totalSum - budget);
            }
            if (budget >= totalSum)
            {
                Console.WriteLine($"You bought {items} items and left with {leftMoney} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {neededMoney} more lv.");
            }
        }
    }
}
