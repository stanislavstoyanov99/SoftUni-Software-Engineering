namespace _05FashionBoutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] clothesInTheBox = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int capacityOfRack = int.Parse(Console.ReadLine());
            Stack<int> stackOfClothes = new Stack<int>(clothesInTheBox);

            int totalCapacity = capacityOfRack;
            int totalRacks = 1;

            while (stackOfClothes.Any())
            {
                int currentCloth = stackOfClothes.Pop();

                if (capacityOfRack - currentCloth == 0)
                {
                    capacityOfRack -= currentCloth;
                    capacityOfRack = totalCapacity;
                    if (stackOfClothes.Count > 0)
                    {
                        totalRacks++;
                    }
                }
                else if (capacityOfRack - currentCloth < 0)
                {
                    totalRacks++;
                    capacityOfRack = totalCapacity;
                    capacityOfRack -= currentCloth;
                }
                else if (capacityOfRack - currentCloth > 0)
                {
                    capacityOfRack -= currentCloth;
                }
            }

            Console.WriteLine(totalRacks);
        }
    }
}
