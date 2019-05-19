using System;
using System.Collections.Generic;
using System.Linq;

namespace _06Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>(); 

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split(" ");
                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string city = tokens[3];


                if (IsStudentExists(students, firstName, lastName))
                {
                    Student student = GetStudent(students, firstName, lastName);   // can be skipped if we use LINQ

                    // rewrite student information
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.City = city;
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = city
                    };

                    students.Add(student);
                }

                /* Another way using LINQ without the method GetStudent
                Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
                if (student == null)
                {
                    students.Add(new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = city
                    });
                }
                else
                {
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.City = city;
                }
                */
            }

            string filterCity = Console.ReadLine();
            var filteredStudents = students.Where(s => s.City == filterCity).ToList();

            filteredStudents.ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName} is {s.Age} years old."));
        }

        static bool IsStudentExists(List<Student> students, string firstName, string lastName)
        {
            var existingStudents = students.Where(s => s.FirstName == firstName && s.LastName == lastName).ToList();

            if (existingStudents.Any())
            {
                return true;
            }

            return false;
            /* Another way using foreach loop
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
            */
        }

        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}
