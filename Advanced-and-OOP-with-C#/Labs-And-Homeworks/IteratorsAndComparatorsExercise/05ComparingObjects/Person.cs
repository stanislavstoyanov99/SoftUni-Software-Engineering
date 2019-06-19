using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparatorsExercise
{
    public class Person : IComparable<Person>
    {
        private List<Person> people;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
            this.people = new List<Person>();
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public void Add(Person person)
        {
            this.people.Add(person);
        }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Age.CompareTo(other.Age) != 0)
            {
                return this.Age.CompareTo(other.Age);
            }

            if (this.Age.CompareTo(other.Age) != 0)
            {
                return this.Town.CompareTo(other.Town);
            }

            return 0;
        }
    }
}
