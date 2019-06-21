using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }

        public int Count => this.gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            Gladiator gladiatorToRemove = this.gladiators.FirstOrDefault(g => g.Name == name);
            this.gladiators.Remove(gladiatorToRemove);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator foundGladiator = this.gladiators
                .OrderByDescending(g => g.GetStatPower())
                .First();

            return foundGladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator foundGladiator = this.gladiators
                .OrderByDescending(g => g.GetWeaponPower())
                .First();

            return foundGladiator;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator foundGladiator = this.gladiators
                .OrderByDescending(g => g.GetTotalPower())
                .First();

            return foundGladiator;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{this.Count}] gladiators are participating.");

            return sb.ToString().TrimEnd();
        }
    }
}
