using System;

namespace _02CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string firstWord = input[0];
            string secondWord = input[1];

            Console.WriteLine(MultiplyCharacters(firstWord, secondWord));
            Console.WriteLine(MultiplyCharactersSecondWay(firstWord, secondWord));
        }

        private static int MultiplyCharacters(string firstWord, string secondWord)
        {
            int totalSum = 0;

            if (firstWord.Length == secondWord.Length)
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    totalSum += firstWord[i] * secondWord[i];
                }
            }
            else
            {
                int rangeForAddition = Math.Abs(firstWord.Length - secondWord.Length);
                int rangeForMultiplication = 0;

                if (firstWord.Length > secondWord.Length)
                {
                    rangeForMultiplication = firstWord.Length - rangeForAddition;

                    for (int i = 0; i < rangeForAddition; i++)
                    {
                        totalSum += firstWord[i + rangeForMultiplication];
                    }
                }
                else
                {
                    rangeForMultiplication = secondWord.Length - rangeForAddition;

                    for (int i = 0; i < rangeForAddition; i++)
                    {
                        totalSum += secondWord[i + rangeForMultiplication];
                    }
                }

                for (int i = 0; i < rangeForMultiplication; i++)
                {
                    totalSum += firstWord[i] * secondWord[i];
                }
            }

            return totalSum;
        }

        // Smarter way with only two loops
        private static int MultiplyCharactersSecondWay(string firstWord, string secondWord)
        {
            int totalSum = 0;

            string longerWord = string.Empty;
            string shorterWord = string.Empty;

            if (firstWord.Length >= secondWord.Length)
            {
                longerWord = firstWord;
                shorterWord = secondWord;
            }
            else
            {
                longerWord = secondWord;
                shorterWord = firstWord;
            }

            for (int i = 0; i < shorterWord.Length; i++)
            {
                totalSum += longerWord[i] * shorterWord[i];
            }

            for (int i = shorterWord.Length; i < longerWord.Length; i++)
            {
                totalSum += longerWord[i];
            }

            return totalSum;
        }
    }
}
