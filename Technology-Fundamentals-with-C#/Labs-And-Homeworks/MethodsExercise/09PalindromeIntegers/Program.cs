using System;
using System.Linq;

namespace _09PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            IsPalindrome();
        }
        static void IsPalindrome()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string reversed = new string(input.ToCharArray().Reverse().ToArray()); // създава се обект от тип стринг с обърнати стойности

                if (input == reversed)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
