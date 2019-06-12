using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FilterByAge
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class Startup
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                var person = new Person(name, age);
                people.Add(person);
            }

            string condition = Console.ReadLine();
            int maxAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, string> peopleFilter = PeopleFilter(people, format);
            Func<Person, bool> ageFilter = AgeFilter(people, condition, maxAge);

            var filteredPeople = people
                .Where(ageFilter)
                .Select(peopleFilter)
                .ToList();

            foreach (var person in filteredPeople)
            {
                Console.WriteLine(person);
            }
        }

        private static Func<Person, bool> AgeFilter(List<Person> people, string condition, int maxAge)
        {
            switch (condition)
            {
                case "older": return person => person.Age >= maxAge;
                case "younger": return person => person.Age < maxAge;
                default: return null;
            }
        }

        private static Func<Person, string> PeopleFilter(List<Person> people, string format)
        {
            switch (format)
            {
                case "name": return person => $"{person.Name}";
                case "age": return person => $"{person.Age}";
                case "name age": return person => $"{person.Name} - {person.Age}";
                default: return null;
            }
        }
    }
}
