using System;

using _05FootballTeamGenerator.Exceptions;

namespace _05FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;

        public Player(string name, Stat stat)
        {
            this.Name = name;
            this.Stat = stat;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }

                this.name = value;
            }
        }

        public Stat Stat { get; private set; }

        public double OverallSkillLevel => this.Stat.AverageStat;
    }
}
