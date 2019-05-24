using System;

class Program
{
    static void Main(string[] args)
    {
        int moneyForPerformer = int.Parse(Console.ReadLine());

        int totalSum = 0;
        int couvertPrice = 0;
        int numberOfGuests = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "The restaurant is full")
            {
                break;
            }
            int peopleNumber = int.Parse(input);

            numberOfGuests += peopleNumber;
            if (peopleNumber >= 5)
            {
                couvertPrice = 70;
            }
            else if (peopleNumber < 5)
            {
                couvertPrice = 100;
            }
            totalSum += peopleNumber * couvertPrice;
        }

        if (totalSum >= moneyForPerformer)
        {
            int leftMoney = totalSum - moneyForPerformer;
            Console.WriteLine($"You have {numberOfGuests} guests and {leftMoney} leva left.");
        }
        else
        {
            Console.WriteLine($"You have {numberOfGuests} guests and {totalSum} leva income, but no singer.");
        }
    }
}
