using System;

namespace _01ChristmasSpirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int daysToChristmas = int.Parse(Console.ReadLine());

            int ornamentSetPrice = 2;
            int treeSkirtPrice = 5;
            int treeGarlandsPrice = 3;
            int treeLightsPrice = 15;

            int totalCost = 0;
            int totalSpirit = 0;

            for (int currentDay = 1; currentDay <= daysToChristmas; currentDay++)
            {
                if (currentDay % 11 == 0)
                {
                    quantity += 2;
                }

                if (currentDay % 10 == 0 && currentDay == daysToChristmas) // if the last day is the 10th reduce the spirit with 30
                {
                    totalSpirit -= 30;
                }

                if (currentDay % 10 == 0)
                {
                    totalSpirit -= 20;
                    totalCost += treeSkirtPrice + treeGarlandsPrice + treeLightsPrice;
                }

                if (currentDay % 5 == 0)
                {
                    totalCost += treeLightsPrice * quantity;
                    totalSpirit += 17;
                    if (currentDay % 3 == 0)
                    {
                        totalSpirit += 30;
                    }
                }

                if (currentDay % 3 == 0)
                {
                    totalCost += treeSkirtPrice * quantity + treeGarlandsPrice * quantity;
                    totalSpirit += 13;
                }

                if (currentDay % 2 == 0)
                {
                    totalCost += ornamentSetPrice * quantity;
                    totalSpirit += 5;
                }
            }

            Console.WriteLine($"Total cost: {totalCost}");
            Console.WriteLine($"Total spirit: {totalSpirit}");
        }
    }
}
