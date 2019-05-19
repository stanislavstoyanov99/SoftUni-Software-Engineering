using System;
using System.Collections.Generic;
using System.Linq;

namespace _07OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> people = new List<People>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personInfo = input.Split(" ");
                string name = personInfo[0];
                string id = personInfo[1];
                int age = int.Parse(personInfo[2]);

                People person = new People(name, id, age);
                people.Add(person);
            }

            people = people.OrderBy(p => p.Age).ToList();

            people.ForEach(p => Console.WriteLine($"{p.Name} with ID: {p.Id} is {p.Age} years old."));
        }
    }

    class People
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public People(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }
    }
}
