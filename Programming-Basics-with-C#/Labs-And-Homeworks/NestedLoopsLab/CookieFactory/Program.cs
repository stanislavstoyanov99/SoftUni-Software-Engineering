using System;

class Program
{
    static void Main(string[] args)
    {
        int numberOfBatches = int.Parse(Console.ReadLine());
        for (int currentBatchNumber = 1; currentBatchNumber <= numberOfBatches; currentBatchNumber++)
        {
            bool isFlourPresent = false;
            bool AreEggsPresent = false;
            bool isSugarPresent = false;

            string productName = Console.ReadLine().ToLower();
            while (true)
            {
                if (productName == "flour")
                {
                    isFlourPresent = true;
                }
                else if (productName == "eggs")
                {
                    AreEggsPresent = true;
                }
                else if (productName == "sugar")
                {
                    isSugarPresent = true;
                }
                else if (productName == "bake!")
                {
                    if (isFlourPresent && AreEggsPresent && isSugarPresent)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The batter should contain flour, eggs and sugar!");
                    }
                }
                productName = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Baking batch number {currentBatchNumber}...");
        }
    }
}
