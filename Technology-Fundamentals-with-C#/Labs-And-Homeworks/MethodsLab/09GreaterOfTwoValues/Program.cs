using System;

namespace _09GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfData = Console.ReadLine();

            switch (typeOfData)
            {
                case "int": GetMaxInt();
                    break;
                case "char": GetMaxChar();
                    break;
                case "string": GetMaxString();
                    break;
            }
        }

        private static void GetMaxInt()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(firstNumber > secondNumber ? firstNumber : secondNumber);
        }

        private static void GetMaxChar()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            Console.WriteLine(firstChar > secondChar ? firstChar : secondChar);
        }

        private static void GetMaxString()
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            Console.WriteLine(firstString.CompareTo(secondString) > 0 ? firstString : secondString);
        }
    }
}
