using System;

class Program
{
    static void Main(string[] args)
    {
        string typeOfSushi = Console.ReadLine();
        string restaurantName = Console.ReadLine();
        int portionNumber = int.Parse(Console.ReadLine());
        string symbol = Console.ReadLine();

        double sum = 0;
        double totalPrice = 0;
        double deliverySum = 0;

        if (restaurantName == "Sushi Zone")
        {
            if (typeOfSushi == "sashimi")
            {
                sum += 4.99;
            }
            else if (typeOfSushi == "maki")
            {
                sum += 5.29;
            }
            else if (typeOfSushi == "uramaki")
            {
                sum += 5.99;
            }
            else if (typeOfSushi == "temaki")
            {
                sum += 4.29;
            }
        }
        else if (restaurantName == "Sushi Time")
        {
            if (typeOfSushi == "sashimi")
            {
                sum += 5.49;
            }
            else if (typeOfSushi == "maki")
            {
                sum += 4.69;
            }
            else if (typeOfSushi == "uramaki")
            {
                sum += 4.49;
            }
            else if (typeOfSushi == "temaki")
            {
                sum += 5.19;
            }
        }
        else if (restaurantName == "Sushi Bar")
        {
            if (typeOfSushi == "sashimi")
            {
                sum += 5.25;
            }
            else if (typeOfSushi == "maki")
            {
                sum += 5.55;
            }
            else if (typeOfSushi == "uramaki")
            {
                sum += 6.25;
            }
            else if (typeOfSushi == "temaki")
            {
                sum += 4.75;
            }
        }
        else if (restaurantName == "Asian Pub")
        {
            if (typeOfSushi == "sashimi")
            {
                sum += 4.50;
            }
            else if (typeOfSushi == "maki")
            {
                sum += 4.80;
            }
            else if (typeOfSushi == "uramaki")
            {
                sum += 5.50;
            }
            else if (typeOfSushi == "temaki")
            {
                sum += 5.50;
            }
        }
        else
        {
            Console.WriteLine($"{restaurantName} is invalid restaurant!");
            return;
        }
        double sushiPrice = portionNumber * sum;
        if (symbol == "Y")
        {
            deliverySum = sushiPrice * 0.20;
            totalPrice = Math.Ceiling(sushiPrice + deliverySum);
            Console.WriteLine($"Total price: {totalPrice} lv.");
        }
        else
        {
            Console.WriteLine($"Total price: {Math.Ceiling(sushiPrice)} lv.");
        }
    }
}
