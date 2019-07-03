using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital_WithClasses
{
    public class Department
    {
        private List<Room> rooms;

        public Department(string name)
        {
            this.Name = name;
            this.rooms = new List<Room>();

            this.CreateRooms();
        }

        public string Name { get; set; }

        public List<Room> GetRooms()
        {
            return this.rooms;
        }

        public void AddPatientInRoom(Patient patient)
        {
            var currentRoom = this.rooms.Where(x => !x.isFull).FirstOrDefault();

            if (currentRoom != null)
            {
                currentRoom.AddPatient(patient);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var room in this.rooms)
            {
                foreach (var patient in room.GetPatients())
                {
                    sb.AppendLine(patient.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }

        private void CreateRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                this.rooms.Add(new Room());
            }
        }
    }
}
