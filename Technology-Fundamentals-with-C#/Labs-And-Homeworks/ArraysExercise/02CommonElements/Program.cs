using System;
using System.Linq;

namespace _02CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(' ').ToArray();
            string[] secondArray = Console.ReadLine().Split(' ').ToArray();
            string[] finalArray = new string[firstArray.Length + secondArray.Length];

            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int j = 0; j < firstArray.Length; j++)
                {
                    if (secondArray[i] == firstArray[j])
                    {
                        finalArray[i] = secondArray[i];
                        //Console.Write($"{secondArray[i]} ");
                        Console.Write(finalArray[i] + " ");
                    }
                }
            }
        }
    }
}
