namespace StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        private Dictionary<string, Student> repo;
        private string[] args;

        public StudentSystem()
        {
            this.repo = new Dictionary<string, Student>();
            this.args = new string[] { };
        }

        public void ParseCommand()
        {
            args = Console.ReadLine().Split();

            if (args[0] == "Create")
            {
                var name = args[1];
                var age = int.Parse(args[2]);
                var grade = double.Parse(args[3]);

                var student = this.CreateStudent(name, age, grade);

                if (!repo.ContainsKey(name))
                {
                    this.repo[name] = student;
                }
            }
            else if (args[0] == "Show")
            {
                ShowStudent();
            }
            else if (args[0] == "Exit")
            {
                ExitProgram();
            }
        }

        private void ShowStudent()
        {
            var name = args[1];

            if (this.repo.ContainsKey(name))
            {
                var student = this.repo[name];

                Console.WriteLine(student);
            }
        }

        private Student CreateStudent(string name, int age, double grade)
        {
            Student student = new Student(name, age, grade);

            return student;
        }

        private void ExitProgram()
        {
            Environment.Exit(0);
        }
    }
}
