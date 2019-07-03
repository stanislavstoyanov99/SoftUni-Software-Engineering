using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;

        public Engine()
        {
            this.doctors = new Dictionary<string, List<string>>();
            this.departments = new Dictionary<string, List<List<string>>>();
        }

        public void Start()
        {
            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();

                string departament = tokens[0];
                string firstName = tokens[1];
                string secondName = tokens[2];
                string patient = tokens[3];
                string fullName = firstName + secondName;

                CreateDoctor(fullName);

                CreateDepartment(departament);

                bool isFreeSpaceAvailable = departments[departament]
                    .SelectMany(x => x)
                    .Count() < 60;

                if (isFreeSpaceAvailable)
                {
                    doctors[fullName].Add(patient);

                    CreateRoom(departament, patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();
                string department = args[0];

                if (args.Length == 1)
                {
                    PrintPatientsInDepartment(department);
                }
                else if (args.Length == 2)
                {
                    string inputRoom = args[1];
                    bool isRoomAvailable = int.TryParse(inputRoom, out int room);

                    if (isRoomAvailable)
                    {
                        PrintPatientsInRoom(department, room);
                    }
                    else
                    {
                        PrintDoctorPatients(department, inputRoom);
                    }
                }

                command = Console.ReadLine();
            }
        }

        private void PrintDoctorPatients(string department, string inputRoom)
        {
            var doctorPatients = doctors[department + inputRoom]
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, doctorPatients));
        }

        private void PrintPatientsInRoom(string department, int room)
        {
            var allPatientsInRoom = departments[department][room - 1]
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsInRoom));
        }

        private void PrintPatientsInDepartment(string department)
        {
            var allPatientsInDepartment = departments[department]
                .Where(x => x.Count > 0)
                .SelectMany(x => x)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsInDepartment));
        }

        private void CreateRoom(string departament, string patient)
        {
            int room = 0;

            for (int currentRoom = 0; currentRoom < departments[departament].Count; currentRoom++)
            {
                if (departments[departament][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }

            departments[departament][room].Add(patient);
        }

        private void CreateDepartment(string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();

                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private void CreateDoctor(string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
