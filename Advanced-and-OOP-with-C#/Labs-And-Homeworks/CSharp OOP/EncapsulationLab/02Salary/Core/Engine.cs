namespace PersonsInfo.Core
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private List<Person> people;

        public Engine()
        {
            this.people = new List<Person>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = CreatePerson(personInfo);

                people.Add(person);
            }

            decimal percentageToIncrease = decimal.Parse(Console.ReadLine());
            IncreaseSalary(percentageToIncrease);

            PrintPeople();
        }

        private Person CreatePerson(string[] personInfo)
        {
            string personFirstName = personInfo[0];
            string personLastName = personInfo[1];
            int personAge = int.Parse(personInfo[2]);
            decimal personSalary = decimal.Parse(personInfo[3]);

            Person person = new Person(personFirstName, personLastName, personAge, personSalary);
            return person;
        }

        private void IncreaseSalary(decimal percentageToIncrease)
        {
            foreach (var person in people)
            {
                person.IncreaseSalary(percentageToIncrease);
            }
        }

        private void PrintPeople()
        {
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
