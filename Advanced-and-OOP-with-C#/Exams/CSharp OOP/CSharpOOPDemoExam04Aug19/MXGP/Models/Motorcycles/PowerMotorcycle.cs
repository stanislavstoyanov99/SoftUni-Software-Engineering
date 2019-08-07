namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Utilities.Messages;

    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;

        private const double CUBIC_CENTIMETERS = 450;

        private const int MinimumHorsePower = 70;

        private const int MaximumHorsePower = 100;

        public PowerMotorcycle(string model, int horsePower)
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
