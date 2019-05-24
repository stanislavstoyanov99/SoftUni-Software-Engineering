using System;

namespace StadiumIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectorsNumber = int.Parse(Console.ReadLine());
            int capacityOfStadium = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());

            double incomeForOneSector = (capacityOfStadium * ticketPrice) / sectorsNumber;
            double totalProfit = incomeForOneSector * sectorsNumber;
            double moneyForCharity = (totalProfit - (incomeForOneSector * 0.75)) / 8;

            Console.WriteLine($"Total income - {totalProfit:F2} BGN");
            Console.WriteLine($"Money for charity - {moneyForCharity:F2} BGN");
        }
    }
}
