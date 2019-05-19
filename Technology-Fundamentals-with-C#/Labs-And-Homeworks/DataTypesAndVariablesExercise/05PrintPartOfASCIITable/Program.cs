using System;

namespace _05PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                char currentCharacter = (char)i;
                Console.Write(currentCharacter + " ");
            }
            Console.WriteLine();
        }
    }
}
