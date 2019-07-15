using System.Text;

using Cars.Interfaces;

namespace Cars.Models
{
    public class Tesla : Car, IElectricCar, ICar
    {
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public int Battery { get; private set; }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public override string Start()
        {
            return base.Start();
        }

        public override string Stop()
        {
            return base.Stop();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
