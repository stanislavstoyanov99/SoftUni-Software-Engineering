using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value > 0)
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.FirstName} {this.LastName} is {this.Age} years old.");

            return sb.ToString().TrimEnd();
        }
    }
}
