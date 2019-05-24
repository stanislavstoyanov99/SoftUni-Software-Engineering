using System;

class Program
{
    static void Main(string[] args)
    {
        string month = Console.ReadLine();
        int totalHours = int.Parse(Console.ReadLine());
        int people = int.Parse(Console.ReadLine());
        string typeOfDay = Console.ReadLine();

        double pricePerHour = default(double);
        double totalSum = default(double);

        bool arePeopleMoreThanFour = people >= 4;
        bool areHoursMoreThanFive = totalHours >= 5;

        if (typeOfDay == "day")
        {
            if (month == "march" || month == "april" || month == "may")
            {
                pricePerHour += 10.50;  
            }
            else if (month == "june" || month == "july" || month == "august")
            {
                pricePerHour += 12.60;
            }
            if (arePeopleMoreThanFour)
            {
                pricePerHour -= (pricePerHour * 0.1);
                totalSum = pricePerHour * people * totalHours;
            }
            if (areHoursMoreThanFive)
            {
                pricePerHour -= pricePerHour * 0.5;
                totalSum = pricePerHour * people * totalHours;
            }

            totalSum = pricePerHour * totalHours * people;
        }
        else if (typeOfDay == "night")
        {
            if (month == "march" || month == "april" || month == "may")
            {
                pricePerHour += 8.40;
            }
            else if (month == "june" || month == "july" || month == "august")
            {
                pricePerHour += 10.20;
            }
            if (arePeopleMoreThanFour)
            {
                pricePerHour -= (pricePerHour * 0.1);
                totalSum = pricePerHour * people * totalHours;
            }
            if (areHoursMoreThanFive)
            {
                pricePerHour -= pricePerHour * 0.5;
                totalSum = pricePerHour * people * totalHours;
            }

            totalSum = pricePerHour * totalHours * people;
        }
        Console.WriteLine($"Price per person for one hour: {pricePerHour:F2}");
        Console.WriteLine($"Total cost of the visit: {totalSum:F2}");
    }
}
