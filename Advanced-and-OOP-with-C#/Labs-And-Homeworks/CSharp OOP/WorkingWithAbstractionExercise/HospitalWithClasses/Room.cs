﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital_WithClasses
{
    public class Room
    {
        public Room()
        {
            this.Patients = new List<Patient>();
        }

        public List<Patient> Patients { get; set; }

        public bool isFull => this.Patients.Count >= 3;

        public void AddPatient(Patient patient)
        {
            if (this.Patients.Count < 3)
            {
                this.Patients.Add(patient);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in this.Patients.OrderBy(x => x.Name))
            {
                sb.AppendLine(patient.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
