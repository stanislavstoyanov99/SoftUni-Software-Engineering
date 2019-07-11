namespace _03Ferrari
{
    public class Ferrari : ICar
    {
        private string model;

        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }

        public string DriverName { get; private set; }

        public string Model
        {
            get
            {
                return "488-Spider";
            }
            private set
            {
                this.model = value;
            }
        }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.GasPedal()}/{this.DriverName}";
        }
    }
}
