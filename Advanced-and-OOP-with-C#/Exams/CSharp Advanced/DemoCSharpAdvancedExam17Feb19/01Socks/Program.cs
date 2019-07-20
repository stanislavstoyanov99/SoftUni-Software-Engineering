using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> leftSocks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> rightSocks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> stackOfLeftSocks = new Stack<int>(leftSocks);
            Queue<int> queueOfRightSocks = new Queue<int>(rightSocks);

            List<int> pairs = new List<int>();

            while (stackOfLeftSocks.Count > 0 && queueOfRightSocks.Count > 0)
            {
                int currentLeftSock = stackOfLeftSocks.Peek();
                int currentRightSock = queueOfRightSocks.Peek();

                if (currentLeftSock > currentRightSock)
                {
                    int pair = currentLeftSock + currentRightSock;
                    pairs.Add(pair);
                    stackOfLeftSocks.Pop();
                    queueOfRightSocks.Dequeue();
                }
                else if (currentLeftSock < currentRightSock)
                {
                    stackOfLeftSocks.Pop();
                }
                else
                {
                    queueOfRightSocks.Dequeue();
                    stackOfLeftSocks.Pop();

                    currentLeftSock++;
                    stackOfLeftSocks.Push(currentLeftSock);
                }
            }

            int biggestPair = pairs.Max();

            Console.WriteLine(biggestPair);
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
