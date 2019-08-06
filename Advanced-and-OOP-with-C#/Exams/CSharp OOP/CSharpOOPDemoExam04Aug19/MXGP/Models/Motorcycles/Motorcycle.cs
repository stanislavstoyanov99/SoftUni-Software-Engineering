using System;

namespace MXGP.Models.Motorcycles
{
    using MXGP.Utilities.Messages;
    using MXGP.Models.Motorcycles.Contracts;

    public abstract class Motorcycle : IMotorcycle
    {
        private string model;

        private int horsePower;

        private const int MINIMUM_POWER_MOTORCYCLE_HORSEPOWER = 70;

        private const int MAXIMUM_POWER_MOTORCYCLE_HORSEPOWER = 100;

        private const int MINIMUM_SPEED_MOTORCYCLE_HORSEPOWER = 50;

        private const int MAXIMUM_SPEED_MOTORCYCLE_HORSEPOWER = 69;

        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel,
                        value, 4));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (this.GetType().Name == "PowerMotorcycle")
                {
                    if (value < MINIMUM_POWER_MOTORCYCLE_HORSEPOWER ||
                        value > MAXIMUM_POWER_MOTORCYCLE_HORSEPOWER)
                    {
                        throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower,
                            value));
                    }
                }

                if (this.GetType().Name == "SpeedMotorcycle")
                {
                    if (value < MINIMUM_SPEED_MOTORCYCLE_HORSEPOWER ||
                        value > MAXIMUM_SPEED_MOTORCYCLE_HORSEPOWER)
                    {
                        throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower,
                            value));
                    }

                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / (this.HorsePower * laps);
        }
    }
}
