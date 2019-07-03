using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital_WithClasses
{
    public class Doctor
    {
        private List<Patient> patients;

        public Doctor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            this.patients = new List<Patient>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;

        public List<Patient> GetPatients()
        {
            return this.patients;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in this.patients.OrderBy(x => x.Name))
            {
                sb.AppendLine(patient.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
