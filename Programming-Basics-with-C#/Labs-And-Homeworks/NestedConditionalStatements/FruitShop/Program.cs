using System;

class Program
{
    static void Main(string[] args)
    {
        string fruit = Console.ReadLine();
        string day = Console.ReadLine();
        double quantity = double.Parse(Console.ReadLine());
        bool isWorkingDay = day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday";
        bool isWeekDay = day == "Saturday" || day == "Sunday";

        double price = default(double);

        if (isWorkingDay)
        {
            switch (fruit)
            {
                case "banana": price = 2.50; break;
                case "apple": price = 1.20; break;
                case "orange": price = 0.85; break;
                case "grapefruit": price = 1.45; break;
                case "kiwi": price = 2.70; break;
                case "pineapple": price = 5.50; break;
                case "grapes": price = 3.85; break;
                default: Console.WriteLine("error"); break;
            }
        }
        else if (isWeekDay)
        {
            switch (fruit)
            {
                case "banana": price = 2.70; break;
                case "apple": price = 1.25; break;
                case "orange": price = 0.90; break;
                case "grapefruit": price = 1.60; break;
                case "kiwi": price = 3.00; break;
                case "pineapple": price = 5.60; break;
                case "grapes": price = 4.20; break;
                default: Console.WriteLine("error"); break;
            }
        }
        else
        {
            Console.WriteLine("error");
            return;
        }
        Console.WriteLine($"{(price * quantity):F2}");
    }
}
