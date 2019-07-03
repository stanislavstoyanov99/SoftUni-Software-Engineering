using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital_WithClasses
{
    public class Hospital
    {
        private List<Department> departments;
        private List<Doctor> doctors;

        public Hospital()
        {
            this.departments = new List<Department>();
            this.doctors = new List<Doctor>();
        }

        public List<Department> GetDepartments()
        {
            return this.departments;
        }

        public List<Doctor> GetDoctors()
        {
            return this.doctors;
        }

        public void AddDoctor(Doctor doctor)
        {
            if (!this.doctors.Any(x => x.FirstName == doctor.FirstName && x.LastName == doctor.LastName))
            {
                this.doctors.Add(doctor);
            }
        }

        public void AddPatient(Doctor doctor, Department department, Patient patient)
        {
            doctor = this.GetDoctors().FirstOrDefault(x => x.FullName == doctor.FullName);
            department = this.GetDepartments().FirstOrDefault(x => x.Name == department.Name);

            doctor.GetPatients().Add(patient);
            department.AddPatientInRoom(patient);
        }

        public void AddDepartment(Department department)
        {
            if (!this.departments.Any(x => x.Name == department.Name))
            {
                this.departments.Add(department);
            }
        }
    }
}
