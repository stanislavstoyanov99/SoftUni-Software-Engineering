using System;

namespace _01SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int[] array = {firstNumber, secondNumber, thirdNumber};

            Array.Sort(array);
            for (int i = 2; i >= 0; i--)
            {
                Console.WriteLine($"{array[i]} ");
            }
        }
    }
}
