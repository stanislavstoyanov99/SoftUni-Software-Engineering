namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Utilities.Messages;

    public class SpeedMotorcycle : Motorcycle
    {
        private int horsePower;

        private const double CUBIC_CENTIMETERS = 125;

        private const int MinimumHorsePower = 50;

        private const int MaximumHorsePower = 69;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, CUBIC_CENTIMETERS)
        {

        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < MinimumHorsePower || value > MaximumHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower,
                        value));
                }

                this.horsePower = value;
            }
        }
    }
}
