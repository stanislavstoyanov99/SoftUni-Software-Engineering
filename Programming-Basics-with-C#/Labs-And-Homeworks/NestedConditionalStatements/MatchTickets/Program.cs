using System;

class Program
{
    static void Main(string[] args)
    {
        double budgetSum = double.Parse(Console.ReadLine());
        string category = Console.ReadLine();
        int totalMembers = int.Parse(Console.ReadLine());

        double currentMoney = default(double);
        double difference = default(double);
        double neededMoney = default(double);

        if (totalMembers >= 1 && totalMembers <= 4)
        {
            currentMoney = budgetSum - (budgetSum * 0.75);
        }
        else if (totalMembers >= 5 && totalMembers <= 9)
        {
            currentMoney = budgetSum - (budgetSum * 0.60);
        }
        else if (totalMembers >= 10 && totalMembers <= 24)
        {
            currentMoney = budgetSum - (budgetSum * 0.50);
        }
        else if (totalMembers >= 25 && totalMembers <= 49)
        {
            currentMoney = budgetSum - (budgetSum * 0.40);
        }
        else if (totalMembers >= 50)
        {
            currentMoney = budgetSum - (budgetSum * 0.25);
        }

        if (category == "Normal")
        {
            double ticketPrice = 249.99 * totalMembers;

            if (ticketPrice < currentMoney)
            {
                difference = Math.Abs(currentMoney - ticketPrice);
                Console.WriteLine($"Yes! You have {difference:F2} leva left.");
            }
            else
            {
                neededMoney = Math.Abs(ticketPrice - currentMoney);
                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
            }
        }
        else if (category == "VIP")
        {
            double ticketPrice = 499.99 * totalMembers;

            if (ticketPrice < currentMoney)
            {
                difference = Math.Abs(currentMoney - ticketPrice);
                Console.WriteLine($"Yes! You have {difference:F2} leva left.");
            }
            else
            {
                neededMoney = Math.Abs(ticketPrice - currentMoney);
                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
            }
        }
    }
}
