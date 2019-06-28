using System;
using System.Collections.Generic;
using System.Linq;

namespace _04EvenTimes
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            int numberOfIntegers = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < numberOfIntegers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currentNumber))
                {
                    numbers.Add(currentNumber, 0);
                }

                numbers[currentNumber]++;
            }

            int evenNumber = numbers.SingleOrDefault(x => x.Value % 2 == 0).Key;

            Console.WriteLine(evenNumber);
        }
    }
}
