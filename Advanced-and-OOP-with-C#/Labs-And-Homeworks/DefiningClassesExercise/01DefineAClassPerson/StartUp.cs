﻿using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person();
            firstPerson.Name = "Pesho";
            firstPerson.Age = 20;

            Person secondPerson = new Person();
            secondPerson.Name = "Gosho";
            secondPerson.Age = 18;

            Person thirdPerson = new Person
            {
                Name = "Stamat",
                Age = 43
            };

            Console.WriteLine($"{firstPerson.Name} - {firstPerson.Age}");
            Console.WriteLine($"{secondPerson.Name} - {secondPerson.Age}");
            Console.WriteLine($"{thirdPerson.Name} - {thirdPerson.Age}");
        }
    }
}
