namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PersonsInfo.Exceptions;

    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team()
        {
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameException);
                }

                this.name = value;
            }
        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get
            {
                return this.firstTeam.AsReadOnly();
            }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get
            {
                return this.reserveTeam.AsReadOnly();
            }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First team has {this.FirstTeam.Count} players.");
            sb.AppendLine($"Reserve team has {this.ReserveTeam.Count} players.");

            return sb.ToString().TrimEnd();
        }
    }
}
