using System;

namespace _01SpringVacationTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTrip = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int theGroupOfPeople = int.Parse(Console.ReadLine());
            double fuelPerKilometer = double.Parse(Console.ReadLine());
            double foodExpensesPerPerson = double.Parse(Console.ReadLine());
            double roomPriceForNightPerPerson = double.Parse(Console.ReadLine());

            double totalFoodExpenses = foodExpensesPerPerson * theGroupOfPeople * daysOfTrip;
            double totalPriceForHotel = roomPriceForNightPerPerson * theGroupOfPeople * daysOfTrip;
            double neededMoney = default(double);

            if (totalPriceForHotel > budget)
            {
                neededMoney = totalPriceForHotel - budget;
                Console.WriteLine($"Not enough money to continue the trip. You need {neededMoney:F2}$ more.");
                return;
            }

            if (theGroupOfPeople > 10)
            {
                totalPriceForHotel -= totalPriceForHotel * 0.25;
            }

            double currentExpenses = totalFoodExpenses + totalPriceForHotel;

            for (int currentDay = 1; currentDay <= daysOfTrip; currentDay++)
            {
                double travelledDistance = double.Parse(Console.ReadLine());
                currentExpenses += travelledDistance * fuelPerKilometer;

                if (currentDay % 7 == 0)
                {
                    currentExpenses -= currentExpenses / theGroupOfPeople;
                }

                if (currentDay % 3 == 0 || currentDay % 5 == 0)
                {
                    currentExpenses += currentExpenses * 0.4;
                }

                if (currentExpenses > budget)
                {
                    neededMoney = currentExpenses - budget;
                    Console.WriteLine($"Not enough money to continue the trip. You need {neededMoney:F2}$ more.");
                    return;
                }
            }

            double leftMoney = budget - currentExpenses;
            Console.WriteLine($"You have reached the destination. You have {leftMoney:F2}$ budget left.");
        }
    }
}
