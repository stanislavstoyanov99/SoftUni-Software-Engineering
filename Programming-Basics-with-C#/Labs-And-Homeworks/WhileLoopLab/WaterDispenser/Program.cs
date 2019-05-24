using System;

class Program
{
    static void Main(string[] args)
    {
        int easyButton = 50;
        int mediumButton = 100;
        int hardButton = 200;

        int totalSum = 0;
        int difference = 0;
        int buttonCount = 0;

        int quantity = int.Parse(Console.ReadLine());
        while (totalSum < quantity)
        {
            string buttonType = Console.ReadLine();
            buttonCount++;
            if (buttonType == "Easy")
            {
                totalSum += easyButton;
            }
            else if (buttonType == "Medium")
            {
                totalSum += mediumButton;
            }
            else
            {
                totalSum += hardButton;
            }
        }
        if (totalSum <= quantity)
        {
            Console.WriteLine($"The dispenser has been tapped {buttonCount} times.");
        }
        else
        {
            difference = Math.Abs(quantity - totalSum);
            Console.WriteLine($"{difference}ml has been spilled.");
        }
    }
}
