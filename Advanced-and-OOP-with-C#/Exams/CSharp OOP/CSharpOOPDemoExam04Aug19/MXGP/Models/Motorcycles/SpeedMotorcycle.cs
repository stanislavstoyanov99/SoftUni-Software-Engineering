namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 125;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CUBIC_CENTIMETERS)
        {

        }
    }
}
