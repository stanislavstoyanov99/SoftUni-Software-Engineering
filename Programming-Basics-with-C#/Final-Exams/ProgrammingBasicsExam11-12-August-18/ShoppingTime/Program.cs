using System;

class Program
{
    static void Main(string[] args)
    {
        int timeForBreak = int.Parse(Console.ReadLine());
        double pricePerPart = double.Parse(Console.ReadLine());
        double pricePerProgram = double.Parse(Console.ReadLine());
        double priceWhiteCoffee = double.Parse(Console.ReadLine());

        double timeForWhiteCoffee = timeForBreak - 5;
        double timeForParts = 6;
        double timeForPrograms = 4;
        double timeForRelax = timeForWhiteCoffee - (timeForParts + timeForPrograms);
        double moneyForParts = pricePerPart * 3;
        double moneyForProgram = pricePerProgram * 2;
        double totalMoney = moneyForParts + moneyForProgram + priceWhiteCoffee;
        double restTime = timeForBreak - (5 + timeForParts + timeForPrograms);

        Console.WriteLine($"{totalMoney:F2}");
        Console.WriteLine($"{restTime}");
    }
}
