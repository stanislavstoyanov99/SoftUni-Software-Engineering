using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Gauss_Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int originalLength = numbers.Count;
            for (int i = 0; i < originalLength / 2; i++) // iterate to the middle of the list
            {
                numbers[i] += numbers[numbers.Count - 1]; // sum the current element with the last one
                numbers.RemoveAt(numbers.Count - 1); // remove the last number
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
