using System;

namespace _01DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                if (int.TryParse(input, out int valueInt)) // Try to parse the string as an integer
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (float.TryParse(input, out float valueFloat)) // Try to parse the string as float
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input, out char valueChar)) // Try to parse the string as char
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out bool valueBool)) // Try to parse the string as bool
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else // string case
                {
                    Console.WriteLine($"{input} is string type");
                }
            }
        }
    }
}
