using System;
using System.Linq;

namespace _04Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var topThree = Console.ReadLine().Split().Select(int.Parse)
                .OrderByDescending(x => x).Take(3);

            foreach (var number in topThree)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
