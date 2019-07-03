using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital_WithClasses
{
    public class Room
    {
        private List<Patient> patients;

        public Room()
        {
            this.patients = new List<Patient>();
        }

        public bool isFull => this.patients.Count >= 3;

        public List<Patient> GetPatients()
        {
            return this.patients;
        }

        public void AddPatient(Patient patient)
        {
            if (this.patients.Count < 3)
            {
                this.patients.Add(patient);
            }
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
