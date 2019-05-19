using System;

namespace _09CharsToString
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());

            string combinedChar = "" + firstChar + secondChar + thirdChar;
            Console.WriteLine(combinedChar);
        }
    }
}
