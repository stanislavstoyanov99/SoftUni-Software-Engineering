using System;

class Program
{
    static void Main(string[] args)
    {
        int guestsNumber = int.Parse(Console.ReadLine());
        int budget = int.Parse(Console.ReadLine());

        int couvertPrice = 20 * guestsNumber;

        if (couvertPrice < budget)
        {
            int remainingMoney = budget - couvertPrice;
            double moneyForFireworks = Math.Ceiling(remainingMoney * 0.40);
            double moneyForCharity = remainingMoney - moneyForFireworks;
            Console.WriteLine($"Yes! {moneyForFireworks} lv are for fireworks and {Math.Ceiling(moneyForCharity)} lv are for donation.");
        }
        else
        {
            double neededMoney = couvertPrice - budget;
            Console.WriteLine($"They won't have enough money to pay the covert. They will need {Math.Ceiling(neededMoney)} lv more.");
        }
    }
}
