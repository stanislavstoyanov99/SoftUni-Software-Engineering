using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Storage storage = new Storage();
            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] infoAboutStudents = Console.ReadLine().Split(" ");
                string firstName = infoAboutStudents[0];
                string lastName = infoAboutStudents[1];
                double grade = double.Parse(infoAboutStudents[2]);

                storage.Students.Add(new Student(firstName, lastName, grade));
            }

            storage.Students = storage.Students.OrderByDescending(s => s.Grade).ToList();
            Console.WriteLine(storage);
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }

    class Storage
    {
        public List<Student> Students { get; set; }

        public Storage()
        {
            Students = new List<Student>();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Students);
        }
    }
}
