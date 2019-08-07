namespace MXGP.Models.Races
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;

    public class Race : IRace
    {
        private string name;

        private int laps;

        private readonly List<IRider> riders;

        private Race()
        {
            this.riders = new List<IRider>();
        }
        public Race(string name, int laps)
            : this()
        {
            this.Name = name;
            this.Laps = laps;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName,
                        value, 5));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(nameof(rider), string.Format(ExceptionMessages.RiderInvalid));
            }

            if (rider.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate,
                    rider.Name));
            }

            bool doesRiderExist = this.riders
                .Any(r => r.Name == rider.Name);

            if (doesRiderExist)
            {
                throw new ArgumentNullException(nameof(rider), string.Format(ExceptionMessages.RiderAlreadyAdded,
                    rider.Name, this.Name));
            }

            this.riders.Add(rider);
        }
    }
}
