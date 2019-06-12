using System;

namespace _02KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = names => 
            Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", names));

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printNames(input);
        }
    }
}
