using System;
using System.Collections.Generic;
using System.Linq;

namespace _05BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> combination = Console.ReadLine().Split().Select(int.Parse).ToList();

            int bombNumber = combination[0];
            int power = combination[1];

            while (numbers.Contains(bombNumber)) // loop until the number is destroyed
            {
                for (int number = 0; number < numbers.Count; number++) // loop the list
                {
                    if (numbers[number] == bombNumber)
                    {
                        int bombIndex = number; // set the bombIndex

                        int frontIndex = bombIndex - power;
                        if (frontIndex < 0) // check if the index is under zero so that no exception can be produced
                        {
                            frontIndex = 0;
                        }

                        int backIndex = bombIndex + power;
                        if (backIndex >= numbers.Count) // check if the index is greather than the size of the list
                        {
                            backIndex = numbers.Count - 1; // set the back index to be the final element of the list
                        }

                        for (int i = frontIndex; i <= backIndex; i++)
                        {
                            numbers.RemoveAt(frontIndex);
                        }
                    }
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
