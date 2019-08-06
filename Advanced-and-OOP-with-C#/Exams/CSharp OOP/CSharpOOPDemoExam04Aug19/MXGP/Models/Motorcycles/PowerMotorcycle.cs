namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 450;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CUBIC_CENTIMETERS)
        {

        }
    }
}
