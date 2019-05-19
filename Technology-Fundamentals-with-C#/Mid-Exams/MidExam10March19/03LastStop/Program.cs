using System;
using System.Collections.Generic;
using System.Linq;

namespace _03LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")                 
            {
                List<string> commands = input.Split(" ").ToList();        
                string command = commands[0];

                //check what command we have received from the list commands
                if (command == "Reverse")
                {
                    numbers.Reverse();
                    continue;   // we need to use continue in order not to read the number, because command reverse does not contain number
                }

                int number = int.Parse(commands[1]);

                if (command == "Hide")
                {
                    if (numbers.Contains(number))   // check whether the number is already in the list numbers
                    {
                        numbers.Remove(number);
                    }
                }
                else if (command == "Change")
                {
                    int changedNumber = int.Parse(commands[2]);

                    if (numbers.Contains(number))   // heck whether the number is already in the list numbers
                    {
                        int index = numbers.IndexOf(number);   // take the index of the number we want to change
                        numbers.Insert(index, changedNumber);  // insert the changed number to this index (changes the indexes of all elements with 1)
                        numbers.RemoveAt(index + 1);           // remove the element so that we have only changed elements in the list
                    }
                }
                else if (command == "Switch")
                {
                    int secondNumber = int.Parse(commands[2]);

                    int firstIndex = numbers.IndexOf(number);   // take the index of the number we want to switch
                    int secondIndex = numbers.IndexOf(secondNumber);   // take the index of the second number

                    if (numbers.Contains(number) && numbers.Contains(secondNumber))   // check whether the numbers are already in the list
                    {
                        numbers.RemoveAt(firstIndex);    // first remove the first index
                        numbers.Insert(firstIndex, secondNumber);   // after that insert the second number on the first index
                        numbers.RemoveAt(secondIndex);   // then the second index
                        numbers.Insert(secondIndex, number);       // and insert the first number to the second index
                    }
                }
                else if (command == "Insert")
                {
                    int paintingNumber = int.Parse(commands[2]);

                    if (number < 0 || number + 1 > numbers.Count - 1)  // check the index (number) to make sure we does not exceed the size of the list
                    {
                        continue;
                    }

                    if (numbers.Contains(numbers[number]))   // check whether the list numbers contains that index (numbers[number])
                    {
                        numbers.Insert(number + 1, paintingNumber);  // insert the painting number after the given index by discription in the problem
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));   // finaly print the list numbers, we can also use foreach
        }
    }
}
