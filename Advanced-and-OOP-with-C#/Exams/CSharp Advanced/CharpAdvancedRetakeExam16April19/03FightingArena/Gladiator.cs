using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetStatPower()
        {
            return Stat.Strength + Stat.Flexibility + Stat.Agility + Stat.Skills + Stat.Intelligence;
        }

        public int GetWeaponPower()
        {
            return Weapon.Size + Weapon.Solidity + Weapon.Sharpness;
        }

        public int GetTotalPower()
        {
            return this.GetStatPower() + this.GetWeaponPower();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]");
            sb.AppendLine($"  Weapon Power: [{this.GetWeaponPower()}]");
            sb.AppendLine($"  Stat Power: [{this.GetStatPower()}]");

            return sb.ToString().TrimEnd();
        }
    }
}
