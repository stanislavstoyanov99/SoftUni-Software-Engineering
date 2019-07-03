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

                string departament = tokens[0];
                string firstName = tokens[1];
                string lastName = tokens[2];
                string patient = tokens[3];
                string fullName = firstName + " " + lastName;

                this.hospital.AddDepartment(departament);
                this.hospital.AddDoctor(firstName, lastName);
                this.hospital.AddPatient(fullName, departament, patient);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string departmentName = args[0];

                if (args.Length == 1)
                {
                    Department department = this.hospital.Departments
                        .FirstOrDefault(x => x.Name == departmentName);

                    Console.WriteLine(department);
                }
                else if (args.Length == 2)
                {
                    string inputRoom = args[1];
                    bool isRoomAvailable = int.TryParse(inputRoom, out int targetRoom);

                    if (isRoomAvailable)
                    {
                        Room room = this.hospital.Departments
                            .FirstOrDefault(x => x.Name == departmentName)
                            .Rooms[targetRoom - 1];

                        Console.WriteLine(room);
                    }
                    else
                    {
                        string fullName = args[0] + " " + args[1];
                        Doctor doctor = this.hospital.Doctors.FirstOrDefault(x => x.FullName == fullName);

                        Console.WriteLine(doctor);
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
