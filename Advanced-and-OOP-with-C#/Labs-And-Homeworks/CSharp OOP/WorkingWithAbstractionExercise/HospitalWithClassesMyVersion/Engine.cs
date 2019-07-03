using System;
using System.Linq;

namespace P04_Hospital_WithClasses
{
    public class Engine
    {
        private Hospital hospital;

        public Engine()
        {
            this.hospital = new Hospital();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string inputDepartment = tokens[0];
                string firstName = tokens[1];
                string lastName = tokens[2];
                string patientName = tokens[3];

                Doctor doctor = new Doctor(firstName, lastName);
                Department department = new Department(inputDepartment);
                Patient patient = new Patient(patientName);

                this.hospital.AddDepartment(department);
                this.hospital.AddDoctor(doctor);
                this.hospital.AddPatient(doctor, department, patient);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string departmentName = args[0];

                if (args.Length == 1)
                {
                    Department department = this.hospital.GetDepartments()
                        .FirstOrDefault(x => x.Name == departmentName);

                    Console.WriteLine(department);
                }
                else if (args.Length == 2)
                {
                    string inputRoom = args[1];
                    bool isRoomAvailable = int.TryParse(inputRoom, out int targetRoom);

                    if (isRoomAvailable)
                    {
                        Room room = this.hospital.GetDepartments()
                            .FirstOrDefault(x => x.Name == departmentName)
                            .GetRooms()
                            .ElementAt(targetRoom - 1);

                        Console.WriteLine(room);
                    }
                    else
                    {
                        string fullName = args[0] + " " + args[1];

                        Doctor doctor = this.hospital.GetDoctors()
                            .FirstOrDefault(x => x.FullName == fullName);

                        Console.WriteLine(doctor);
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
