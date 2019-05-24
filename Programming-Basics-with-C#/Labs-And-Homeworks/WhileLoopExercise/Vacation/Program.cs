using System;

class Program
{
    static void Main(string[] args)
    {
        double vacationMoneyNeeded = double.Parse(Console.ReadLine());
        double currentMoney = double.Parse(Console.ReadLine());
        string action = string.Empty;
        double transaction = default(double);
        string result = string.Empty;

        double diff = 0;

        int spendCount = 0;
        int daysCount = 0;

        while (true)
        {
            action = Console.ReadLine();
            transaction = double.Parse(Console.ReadLine());
            daysCount++;

            if (action == "spend")
            {
                spendCount++;
                diff = currentMoney - transaction;
                currentMoney -= transaction;
                if (diff < 0)
                {
                    currentMoney = 0;
                }
            }
            else if (action == "save")
            {
                spendCount = 0;
                currentMoney += transaction;
            }
            if (spendCount == 5)
            {
                result = $"You can't save the money." + Environment.NewLine + daysCount;
                break;
            }
            if (currentMoney >= vacationMoneyNeeded)
            {
                result = $"You saved the money for {daysCount} days.";
                break;
            }
        }
        Console.WriteLine(result);
    }
}
