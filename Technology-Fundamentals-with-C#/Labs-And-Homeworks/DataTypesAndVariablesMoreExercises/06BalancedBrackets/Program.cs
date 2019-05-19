using System;

namespace _06BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            int openingBracket = 0;
            int closingBracket = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();
                if (input == "(")
                {
                    openingBracket++;
                }
                else if (input == ")")
                {
                    closingBracket++;
                }

                if (closingBracket > openingBracket)
                {
                    break;
                }
            }

            if (closingBracket == openingBracket)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
