using System;
using System.Collections.Generic;
using System.Linq;

namespace _03HousеParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 1; i <= numberOfCommands; i++)
            {
                List<string> command = Console.ReadLine().Split().ToList(); // read the current command (we can use list or array)

                if (command.Count == 3) // {name} is going! (length = 3)
                {
                    //isInTheList = guests.Contains(command[0]); the same as the code below
                    bool isInTheList = guests.Any(x => x.Equals(command[0]));

                    //foreach (string name in guests) // loop all names in the guest List
                    //{
                    //    if (name.Equals(command[0])) // check whether the name exists already
                    //    {
                    //        isInTheList = true;
                    //        break;
                    //    }
                    //}

                    if (isInTheList) 
                    {
                        Console.WriteLine($"{command[0]} is already in the list!"); // print this message, if the name exists already
                    }
                    else
                    {
                        guests.Add(command[0]); // otherwise add the name to the list
                    }
                }
                else // if the command is "{name} is not going!"
                {
                    if (!guests.Contains(command[0])) // check to see that the name is not in the list
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                    }
                    else // otherwise remove the name from the list (if the name exists in the list)
                    {
                        guests.Remove(command[0]);
                    }
                }
            }

            guests.ForEach(Console.WriteLine);
        }
    }
}
