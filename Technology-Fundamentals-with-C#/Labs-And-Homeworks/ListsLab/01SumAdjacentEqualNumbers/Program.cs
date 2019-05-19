using System;
using System.Collections.Generic;
using System.Linq;

namespace _01SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (int i = 0; i < numbers.Count - 1; i++)  // numbers.Count - 1 because of the index of each element
            {
                if (numbers[i] == numbers[i + 1])  // check whether the current element is equal to the next number
                {
                    numbers[i] += numbers[i + 1];  // sum the current element and the next
                    numbers.RemoveAt(i + 1);  // removes the next number
                    i = -1;  // reset the counter in order to start from the beginning of the list
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
