using System;
using System.Collections.Generic;
using System.Linq;

namespace _03QuestsJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ").ToList();  // create the initial list journal
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Retire!")                 // loop until the command is "Retire!"
            {
                List<string> commands = input.Split(" - ").ToList();        // create another list with the commands
                string command = commands[0];                              // set the zero index for the command
                string quest = commands[1];                               // set the first index for the quest

                bool isQuestExists = journal.Contains(quest);           // make a bool variable for the existence of the quest in the list journal
                if (command == "Start")
                {
                    if (!isQuestExists)
                    {
                        journal.Add(quest);
                    }
                }
                else if (command == "Complete")
                {
                    if (isQuestExists)
                    {
                        journal.Remove(quest);
                    }
                }
                else if (command == "Side Quest")
                {
                    string[] newQuest = quest.Split(":");      // create an array  to split the quest by ":"
                    quest = newQuest[0];                      // set the quest to be the zero index of the array
                    string sideQuest = newQuest[1];          // set the side quest to be the first index of the array

                    if (journal.Contains(quest) && !journal.Contains(sideQuest))
                    {
                        // using lambda expression to find the index of the quest
                        //int index = journal.FindIndex(x => x == quest); 
                        int index = journal.IndexOf(quest);
                        journal.Insert(index + 1, sideQuest);   // insert the sideQuest after the quest
                    }
                }
                else if (command == "Renew")
                {
                    if (journal.Contains(quest))
                    {
                        journal.Remove(quest);
                        journal.Add(quest);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
