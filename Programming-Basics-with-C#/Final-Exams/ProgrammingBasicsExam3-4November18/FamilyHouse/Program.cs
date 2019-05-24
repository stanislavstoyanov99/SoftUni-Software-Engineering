using System;

class Program
{
    static void Main(string[] args)
    {
        int months = int.Parse(Console.ReadLine());

        double waterPrice = months * 20;
        double netPrice = months * 15;

        double moneyForElectricityBill = 0;
        double otherBill = 0;
        double totalSumForOtherBill = 0;
        double totalSum = 0;

        for (int i = 1; i <= months; i++)
        {
            double electricityBill = double.Parse(Console.ReadLine());
            moneyForElectricityBill += electricityBill;
            otherBill += (electricityBill + 20 + 15) * 0.20;
            totalSumForOtherBill += otherBill + (electricityBill + 20 + 15);
            totalSum = totalSumForOtherBill + waterPrice + netPrice + moneyForElectricityBill;
            otherBill = 0;
        }

        double averageSum = totalSum / months;
        Console.WriteLine($"Electricity: {moneyForElectricityBill:F2} lv");
        Console.WriteLine($"Water: {waterPrice:F2} lv");
        Console.WriteLine($"Internet: {netPrice:F2} lv");
        Console.WriteLine($"Other: {totalSumForOtherBill:F2} lv");
        Console.WriteLine($"Average: {averageSum:F2} lv");
    }
}
