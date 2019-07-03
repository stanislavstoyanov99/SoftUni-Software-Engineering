using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital_WithClasses
{
    public class Hospital
    {
        public Hospital()
        {
            this.Departments = new List<Department>();
            this.Doctors = new List<Doctor>();
        }

        public List<Department> Departments { get; set; }

        public List<Doctor> Doctors { get; set; }

        public void AddDoctor(string firstName, string lastName)
        {
            if (!this.Doctors.Any(x => x.FirstName == firstName && x.LastName == lastName))
            {
                Doctor doctor = new Doctor(firstName, lastName);
                this.Doctors.Add(doctor);
            }
        }

        public void AddPatient(string doctorName, string departmentName, string patientName)
        {
            Doctor doctor = this.Doctors.FirstOrDefault(x => x.FullName == doctorName);
            Department department = this.Departments.FirstOrDefault(x => x.Name == departmentName);

            Patient patient = new Patient(patientName);

            doctor.Patients.Add(patient);
            department.AddPatientInRoom(patient);
        }

        public void AddDepartment(string name)
        {
            if (!this.Departments.Any(x => x.Name == name))
            {
                Department department = new Department(name);
                this.Departments.Add(department);
            }
        }
    }
}
