using System;
using System.Collections.Generic;
using System.Linq;

namespace _03TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> inputMessage = Console.ReadLine().ToList();

            List<int> numbers = new List<int>();

            for (int i = 0; i < inputMessage.Count; i++)
            {
                if (char.IsDigit(inputMessage[i]))
                {
                    int currentNumber = inputMessage[i] - '0';
                    numbers.Add(currentNumber);
                    inputMessage.RemoveAt(i);
                    i--;
                }
            }

            List<int> takeList = numbers.Where((item, index) => index % 2 == 0).ToList();
            List<int> skipList = numbers.Where((item, index) => index % 2 != 0).ToList();

            List<char> result = new List<char>();

            for (int i = 0; i < takeList.Count; i++)
            {
                if (takeList[i] >= inputMessage.Count)
                {
                    takeList[i] = inputMessage.Count;
                }

                result.AddRange(inputMessage.GetRange(0, takeList[i]));
                inputMessage.RemoveRange(0, takeList[i]);

                if (skipList[i] > inputMessage.Count)
                {
                    skipList[i] = inputMessage.Count;
                }

                inputMessage.RemoveRange(0, skipList[i]);
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
