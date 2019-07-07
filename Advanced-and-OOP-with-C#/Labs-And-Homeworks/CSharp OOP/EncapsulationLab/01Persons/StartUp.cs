using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = personInfo[0];
                string lastName = personInfo[1];
                int age = int.Parse(personInfo[2]);

                var person = new Person(firstName, lastName, age);

                people.Add(person);
            }

            var filteredPeople = people
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList();

            foreach (var person in filteredPeople)
            {
                Console.WriteLine(person);
            }
        }
    }
}
