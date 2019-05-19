using System;

namespace _02VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            VowelsCount();
        }
        static void VowelsCount()
        {
            string input = Console.ReadLine().ToLower();
            int countOfVowels = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || 
                    input[i] == 'e' || 
                    input[i] == 'i' || 
                    input[i] == 'o' || 
                    input[i] == 'u')
                {
                    countOfVowels++;
                }
            }
            Console.WriteLine(countOfVowels);
        }
    }
}
