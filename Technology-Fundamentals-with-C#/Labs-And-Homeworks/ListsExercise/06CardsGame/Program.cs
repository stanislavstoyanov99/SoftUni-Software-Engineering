using System;
using System.Collections.Generic;
using System.Linq;

namespace _06CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondHand = Console.ReadLine().Split().Select(int.Parse).ToList();

            int length = firstHand.Count; // only in case both lists are identical (with the same size)

            while (length > 0)
            {
                if (firstHand[0] > secondHand[0])
                {
                    firstHand.Add(firstHand[0]); // add the winning card to the firstHand deck
                    firstHand.Add(secondHand[0]); // add the second card after the winning one
                }
                else if (secondHand[0] > firstHand[0])
                {
                    secondHand.Add(secondHand[0]); // add the winning card to the secondHand deck
                    secondHand.Add(firstHand[0]); // add the second card after the winning one
                }

                // no matter who wins, we need to remove the cards that are checked in order not to recieve argument exception
                firstHand.RemoveAt(0); // removes the first card from the first deck
                secondHand.RemoveAt(0); // remove the first card from the second deck

                if (firstHand.Count < secondHand.Count) //we need to keep track of both hands to know when the game ends
                {
                    length = firstHand.Count;
                }
                else
                {
                    length = secondHand.Count;
                }
            }

            if (firstHand.Any()) // check who is the winner and sum the remaining cards
            {
                Console.WriteLine($"First player wins! Sum: {firstHand.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondHand.Sum()}");
            }
        }
    }
}
