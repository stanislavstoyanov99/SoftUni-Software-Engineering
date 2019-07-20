using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Astronaut astronaut)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            bool result = false;
            Astronaut astronautToRemove = this.data.FirstOrDefault(a => a.Name == name);

            if (this.data.Contains(astronautToRemove))
            {
                result = true;
                this.data.Remove(astronautToRemove);
            }

            return result;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut oldestAstronaut = this.data
                .OrderByDescending(a => a.Age)
                .First();

            return oldestAstronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut foundAstronaut = this.data.FirstOrDefault(a => a.Name == name);

            return foundAstronaut;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.data)
            {
                sb.AppendLine($"{astronaut.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
