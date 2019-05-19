using System;
using System.Collections.Generic;
using System.Linq;

namespace _05Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();   // create list with the class Student

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")   // loop until the command "end"
            {
                string[] tokens = input.Split(" ");   // for each input make array with the information about the student
                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string city = tokens[3];

                Student student = new Student(firstName, lastName, age, city);   // create object from the class Student with the given parameters
                students.Add(student);   // add the current studen to the list students
            }

            string filterCity = Console.ReadLine();
            List<Student> filteredStudents = students.Where(s => s.City == filterCity).ToList();   // make a new list for the filtered students

            filteredStudents.ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName} is {s.Age} years old."));
            
            /* Another way without LINQ and extension method
            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
            */
        }
    }

    class Student
    {
        // fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public Student(string firstName, string lastName, int age, string city)   // constructor
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            City = city;
        }
    }
}
