using System;

class Program
{
    static void Main(string[] args)
    {
        int totalMoney = int.Parse(Console.ReadLine());
        int spentMoney = 0;
        int boughtClothes = 0;

        while (!(totalMoney == 0))
        {
            string input = Console.ReadLine();
            if (input == "enough")
            {
                break;
            }
            else if (input == "enter")
            {
                while (true)
                {
                    input = Console.ReadLine();
                    if (input == "leave")
                    {
                        break;
                    }
                    int inputAsNumber = int.Parse(input);

                    if (inputAsNumber > totalMoney)
                    {
                        Console.WriteLine("Not enough money.");
                        continue;
                    }

                    totalMoney -= inputAsNumber;
                    spentMoney += inputAsNumber;
                    boughtClothes++;

                    if (totalMoney == 0)
                    {
                        break;
                    }
                }
            }
        }
        Console.WriteLine($"For {boughtClothes} clothes I spent {spentMoney} lv and have {totalMoney} lv left.");
    }
}
