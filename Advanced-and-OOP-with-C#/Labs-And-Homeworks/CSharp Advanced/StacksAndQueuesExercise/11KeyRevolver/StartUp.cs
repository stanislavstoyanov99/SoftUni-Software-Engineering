using System;
using System.Collections.Generic;
using System.Linq;

namespace _11KeyRevolver
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int priceOfEachBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stackOfBullets = new Stack<int>(bullets);
            Queue<int> queueOfLocks = new Queue<int>(locks);

            int numberOfUsedBullets = 0;
            bool isTheSafeOpened = true;

            while (stackOfBullets.Count > 0 && queueOfLocks.Count > 0)
            {
                if (stackOfBullets.Peek() <= queueOfLocks.Peek())
                {
                    Console.WriteLine("Bang!");
                    stackOfBullets.Pop();
                    queueOfLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    stackOfBullets.Pop();
                }
                numberOfUsedBullets++;

                if (numberOfUsedBullets % sizeOfGunBarrel == 0 & stackOfBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }

                if (stackOfBullets.Count == 0 && queueOfLocks.Count > 0)
                {
                    isTheSafeOpened = false;
                    break;
                }
            }

            if (isTheSafeOpened)
            {
                int bulletCost = numberOfUsedBullets * priceOfEachBullet;
                int earnedMoney = valueOfIntelligence - bulletCost;

                Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${earnedMoney}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueOfLocks.Count}");
            }
        }
    }
}
