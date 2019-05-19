using System;
using System.Linq;

namespace _09KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfSequences = int.Parse(Console.ReadLine());

            int longestSubsequence = -1;
            int longestSubIndex = -1;
            int longestSubSum = -1;
            int indexOfLongest = 0;
            int[] sequence = new int[lengthOfSequences];

            string input = Console.ReadLine();

            int indexOfSequence = 1;

            while (input != "Clone them!")
            {
                int[] currentSequence = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int subsequence = 0;
                int subIndex = -1;
                int subSum = 0;

                int count = 0;
                for (int i = 0; i < lengthOfSequences; i++)
                {
                    if (currentSequence[i] == 1)
                    {
                        count++;
                        subSum++;
                        if (count > subsequence)
                        {
                            subsequence = count;
                            subIndex = i - count;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }

                if (subsequence > longestSubsequence)
                {
                    longestSubIndex = subIndex;
                    longestSubsequence = subsequence;
                    longestSubSum = subSum;
                    sequence = currentSequence;
                    indexOfLongest = indexOfSequence;
                }
                else if (subsequence == longestSubsequence 
                    && longestSubIndex > subIndex)
                {
                    longestSubIndex = subIndex;
                    longestSubSum = subSum;
                    sequence = currentSequence;
                    indexOfLongest = indexOfSequence;
                }
                else if (subsequence == longestSubsequence
                    && longestSubIndex == subIndex 
                    && longestSubSum < subSum)
                {
                    longestSubSum = subSum;
                    sequence = currentSequence;
                    indexOfLongest = indexOfSequence;
                }

                indexOfSequence++;
                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {indexOfLongest} with sum: {longestSubSum}.");
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
