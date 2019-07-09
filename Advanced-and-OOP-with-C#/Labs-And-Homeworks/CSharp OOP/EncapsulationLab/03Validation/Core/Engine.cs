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

                AddPersonToCollection(personInfo);
            }

            decimal percentageToIncrease = decimal.Parse(Console.ReadLine());

            IncreaseSalary(percentageToIncrease);

            PrintPeople();
        }

        private void IncreaseSalary(decimal percentageToIncrease)
        {
            foreach (var person in people)
            {
                person.IncreaseSalary(percentageToIncrease);
            }
        }

        private void AddPersonToCollection(string[] personInfo)
        {
            try
            {
                string firstName = personInfo[0];
                string lastName = personInfo[1];
                int age = int.Parse(personInfo[2]);
                decimal salary = decimal.Parse(personInfo[3]);

                Person person = new Person(firstName, lastName, age, salary);
                people.Add(person);
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
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