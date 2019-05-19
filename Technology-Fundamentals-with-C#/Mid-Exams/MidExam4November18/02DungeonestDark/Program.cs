using System;

namespace _02DungeonestDark
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonsRoom = Console.ReadLine().Split("|");       // make an array/list for the input
            int initialHealth = 100;                                    // set the initial health to 100
            int totalCoins = 0;                                        // set the initial coins to 0

            //two counters for the number of events and best rooms
            int counterEvents = 0;
            int bestRoomCounter = 0;

            for (int currentEvent = 0; currentEvent < dungeonsRoom.Length; currentEvent++)     // loop all the array/list
            {
                string[] tokens = dungeonsRoom[currentEvent].Split(" ");         // make inner array/list for storing the event information
                string command = tokens[0];                                     // the zero index is the type of event
                int number = int.Parse(tokens[1]);                             // the first index is the number given by exercise

                // check what command we are having
                if (command == "potion")
                {
                    bestRoomCounter++;
                    if (initialHealth + number <= 100)                     // check whether the initial health + number is below or equal to 100
                    {
                        initialHealth += number;
                        Console.WriteLine($"You healed for {number} hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                    }
                    else                                                 // otherwise the number will be decreased by the initial health
                    {
                        number = 100 - initialHealth;
                        initialHealth = 100;
                        Console.WriteLine($"You healed for {number} hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                    }
                }
                else if (command == "chest")
                {
                    bestRoomCounter++;
                    totalCoins += number;                              // add the number to the total coins
                    Console.WriteLine($"You found {number} coins.");
                }
                else
                {
                    bestRoomCounter++;
                    initialHealth -= number;

                    if (initialHealth > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {bestRoomCounter}");
                        return;
                    }
                }

                counterEvents++;                                     // increase the counter so that we know the exact number of events happened
            }

            if (counterEvents == dungeonsRoom.Length)               // check the counter to see whether all events are made
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Coins: {totalCoins}");
                Console.WriteLine($"Health: {initialHealth}");
            }
        }
    }
}
