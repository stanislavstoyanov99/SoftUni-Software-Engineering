using System;

class Program
{
    static void Main(string[] args)
    {
        double budget = double.Parse(Console.ReadLine());
        string town = Console.ReadLine();
        int nights = int.Parse(Console.ReadLine());

        double pricePerNight = default(double);
        double flightTicket = default(double);
        double discountSum = default(double);
        double finalSum = default(double);
        double totalSum = default(double);

        if (town == "Cairo")
        {
            pricePerNight += 500 * nights;
            flightTicket += 600;
            totalSum += pricePerNight + flightTicket;

            if (nights >= 50)
            {
                discountSum = totalSum * 0.30;
            }
            else if (nights >= 25 && nights <= 49)
            {
                discountSum = totalSum * 0.17;
            }
            else if (nights >= 10 && nights <= 24)
            {
                discountSum = totalSum * 0.10;
            }
            else if (nights >= 5 && nights <= 9)
            {
                discountSum = totalSum * 0.05;
            }
            else if (nights >= 1 && nights <= 4)
            {
                discountSum = totalSum * 0.03;
            }
        }
        else if (town == "Paris")
        {
            pricePerNight += 300 * nights;
            flightTicket += 350;
            totalSum += pricePerNight + flightTicket;

            if (nights >= 50)
            {
                discountSum = totalSum * 0.30;
            }
            else if (nights >= 25 && nights <= 49)
            {
                discountSum = totalSum * 0.22;
            }
            else if (nights >= 10 && nights <= 24)
            {
                discountSum = totalSum * 0.12;
            }
            else if (nights >= 5 && nights <= 9)
            {
                discountSum = totalSum * 0.07;
            }
        }
        else if (town == "Lima")
        {
            pricePerNight += 800 * nights;
            flightTicket += 850;
            totalSum += pricePerNight + flightTicket;

            if (nights >= 50)
            {
                discountSum = totalSum * 0.30;
            }
            else if (nights >= 25 && nights <= 49)
            {
                discountSum = totalSum * 0.19;
            }
        }
        else if (town == "New York")
        {
            pricePerNight += 600 * nights;
            flightTicket += 650;
            totalSum += pricePerNight + flightTicket;

            if (nights >= 50)
            {
                discountSum = totalSum * 0.30;
            }
            else if (nights >= 25 && nights <= 49)
            {
                discountSum = totalSum * 0.19;
            }
            else if (nights >= 10 && nights <= 24)
            {
                discountSum = totalSum * 0.12;
            }
            else if (nights >= 5 && nights <= 9)
            {
                discountSum = totalSum * 0.05;
            }
            else if (nights >= 1 && nights <= 4)
            {
                discountSum = totalSum * 0.03;
            }
        }
        else if (town == "Tokyo")
        {
            pricePerNight += 700 * nights;
            flightTicket += 700;
            totalSum += pricePerNight + flightTicket;

            if (nights >= 50)
            {
                discountSum = totalSum * 0.30;
            }
            else if (nights >= 25 && nights <= 49)
            {
                discountSum = totalSum  * 0.17;
            }
            else if (nights >= 10 && nights <= 24)
            {
                discountSum = totalSum * 0.12;
            }
        }

        finalSum = totalSum - discountSum;
        if (finalSum <= budget)
        {
            double remainingMoney = budget - finalSum;
            Console.WriteLine($"Yes! You have {remainingMoney:F2} leva left.");
        }
        else
        {
            double neededMoney = finalSum - budget;
            Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
        }
    }
}