using System;
using System.Collections.Generic;

namespace IteratorsAndComparatorsExercise
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int countOfMatches = 1;
            int countOfNotEqualPeople = 0;

            int personToCompare = int.Parse(Console.ReadLine());
            Person targetPerson = people[personToCompare - 1];

            foreach (var person in people)
            {
                if (person == targetPerson)
                {
                    continue;
                }

                if (person.CompareTo(targetPerson) == 0)
                {
                    countOfMatches++;
                }
                else
                {
                    countOfNotEqualPeople++;
                }
            }

            if (countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {countOfNotEqualPeople} {people.Count}");
            }
        }
    }
}
