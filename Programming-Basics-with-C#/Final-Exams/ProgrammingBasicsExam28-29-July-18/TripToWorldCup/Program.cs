using System;

namespace TripToWorldCup
{
    class Program
    {
        static void Main(string[] args)
        {
            double ticketPriceForGoing = double.Parse(Console.ReadLine()); 
            double ticketPriceForArriving = double.Parse(Console.ReadLine());
            double ticketPriceForMatch = double.Parse(Console.ReadLine());
            double matchesNumber = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine()) / 100;

            double sumForPlaneTickets = 6 * (ticketPriceForGoing + ticketPriceForArriving);
            double currentSum = sumForPlaneTickets * discount;
            double discountSum = sumForPlaneTickets - currentSum;
            double totalSumForMatches = 6 * matchesNumber * ticketPriceForMatch;
            double totalSum = discountSum + totalSumForMatches;
            double sumPerPerson = totalSum / 6;

            Console.WriteLine($"Total sum: {totalSum:F2} lv.");
            Console.WriteLine($"Each friend has to pay {sumPerPerson:F2} lv.");
        }
    }
}
