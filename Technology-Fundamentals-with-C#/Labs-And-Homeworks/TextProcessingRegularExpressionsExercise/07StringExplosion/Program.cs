using System;

namespace _07StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int strengthOfExplosion = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (strengthOfExplosion > 0 && input[i] != '>')
                {
                    input = input.Remove(i, 1);     // Remove char on this index
                    strengthOfExplosion--;         // One bomb is used and we reduce the strength of explosion
                    i--;                          // after removing, the next char is moved 1 position, so decrease the counter with 1
                }
                else if (input[i] == '>')
                {
                    strengthOfExplosion += int.Parse(input[i + 1].ToString());     // takes the digit after '>' - strenght of explosion
                }
            }

            Console.WriteLine(input);
        }
    }
}
