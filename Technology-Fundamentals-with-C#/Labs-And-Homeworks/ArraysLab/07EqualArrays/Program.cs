using System;
using System.Linq;

namespace _07EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sumOfFirstArray = 0;
            bool areEqual = Enumerable.SequenceEqual(firstArray, secondArray); // checks the content of each array

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (areEqual) // equal elements
                {
                    sumOfFirstArray += firstArray[i]; // calculate the sum
                }
                else // not equal elements
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                        break;
                    }
                }
            }

            if (areEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sumOfFirstArray}");
            }

            //Second way
            //bool areEqual = false;

            //for (int i = 0; i < firstArray.Length; i++)
            //{
            //    if (firstArray[i] != secondArray[i]) // not equal elements
            //    {
            //        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
            //        areEqual = true;
            //        break;
            //    }
            //    else // equal elements
            //    {
            //        sumOfFirstArray += firstArray[i]; // calculate the sum
            //    }
            //}

            //if (!areEqual) // check the flag if they are equal and print the sum
            //{
            //    Console.WriteLine($"Arrays are identical. Sum: {sumOfFirstArray}");
            //}
        }
    }
}
