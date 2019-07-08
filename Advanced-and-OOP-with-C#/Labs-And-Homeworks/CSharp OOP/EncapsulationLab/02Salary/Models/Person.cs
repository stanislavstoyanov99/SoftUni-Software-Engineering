namespace PersonsInfo
{
    using System.Text;

    public class Person
    {
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
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

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            private set
            {
                if (value > 0)
                {
                    this.salary = value;
                }
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary += this.Salary * percentage / 100;
            }
            else
            {
                this.Salary += this.Salary * percentage / 200;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.");

            return sb.ToString().TrimEnd();
        }
    }
}
