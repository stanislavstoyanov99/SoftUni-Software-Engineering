using System;
using System.Collections.Generic;
using System.Linq;

namespace _09PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> removedElements = new List<int>();

            while (numbers.Any())
            {
                int indexToRemove = int.Parse(Console.ReadLine());

                if (indexToRemove < 0)
                {
                    removedElements.Add(numbers[0]); // add the removed number to the list removedElements
                    numbers.Remove(numbers[0]); // remove that number from the list numbers
                    numbers.Insert(0, numbers[numbers.Count - 1]); // insert the last element to the first place of the list numbers

                    IncreaseAndDecreaseValue(numbers, removedElements, indexToRemove);
                    continue;
                }
                else if (indexToRemove > numbers.Count - 1)
                {
                    removedElements.Add(numbers[numbers.Count - 1]); // add the (last) removed element to the list removedElements
                    numbers.RemoveAt(numbers.Count - 1); // remove the last element from the list numbers
                    numbers.Insert(numbers.Count, numbers[0]); // insert the first element to the last  place of the list numbers

                    IncreaseAndDecreaseValue(numbers, removedElements, indexToRemove);
                    continue;
                }

                removedElements.Add(numbers[indexToRemove]); // add the number that we want to remove to the removedElements list
                numbers.RemoveAt(indexToRemove); // remove that number from the list numbers

                IncreaseAndDecreaseValue(numbers, removedElements, indexToRemove);
            }

            Console.WriteLine(removedElements.Sum());
        }

        static void IncreaseAndDecreaseValue(List<int> numbers, List<int> removedElements, int indexToRemove)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= removedElements[removedElements.Count - 1])
                {
                    numbers[i] += removedElements[removedElements.Count - 1]; // increase the value of the current element with the removed one
                }
                else if (numbers[i] > removedElements[removedElements.Count - 1])
                {
                    numbers[i] -= removedElements[removedElements.Count - 1]; // decrease the value of the current element with the removed one
                }
            }
        }
    }
}
