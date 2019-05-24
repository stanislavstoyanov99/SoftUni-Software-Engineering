using System;

class Program
{
    static void Main(string[] args)
    {
        int budget = int.Parse(Console.ReadLine());
        int numberOfItems= int.Parse(Console.ReadLine());

        int sum = 0;
        int numberOfBoughtItems = 0;

        for (int i = 0; i < numberOfItems; i++)
        {
            string item = Console.ReadLine();
            switch (item)
            {
                case "hoodie": sum += 30; break;
                case "keychain": sum += 4; break;
                case "T-shirt": sum += 20; break;
                case "flag": sum += 15; break;
                case "sticker": sum += 1; break;
            }
            numberOfBoughtItems++;
        }
        if (budget >= sum)
        {
            int leftMoney = budget - sum;
            Console.WriteLine($"You bought {numberOfBoughtItems} items and left with {leftMoney} lv.");
        }
        else
        {
            int neededMoney = sum - budget;
            Console.WriteLine($"Not enough money, you need {neededMoney} more lv.");
        }
    }
}
