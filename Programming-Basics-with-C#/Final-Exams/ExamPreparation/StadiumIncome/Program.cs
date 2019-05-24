using System;

class Program
{
    static void Main(string[] args)
    {
        int numberOfSectors = int.Parse(Console.ReadLine());
        int capacityOfStadium = int.Parse(Console.ReadLine());
        double priceOfTicket = double.Parse(Console.ReadLine());

        double totalIncome = capacityOfStadium * priceOfTicket;
        double incomeForSector = totalIncome / numberOfSectors;
        double moneyForCharity = (totalIncome - (incomeForSector * 0.75)) / 8;

        Console.WriteLine($"Total income - {totalIncome:F2} BGN");
        Console.WriteLine($"Money for charity - {moneyForCharity:F2} BGN");
    }
}
