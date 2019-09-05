namespace AnimalCentre.Models.Animals
{
    using System;

    using AnimalCentre.Models.Contracts;
    using AnimalCentre.Utilities.Messages;

    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;

        public Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }

        public string Name { get; set; }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappinessValue);
                }

                this.happiness = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergyValue);
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; } = "Centre";

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }
    }
}
