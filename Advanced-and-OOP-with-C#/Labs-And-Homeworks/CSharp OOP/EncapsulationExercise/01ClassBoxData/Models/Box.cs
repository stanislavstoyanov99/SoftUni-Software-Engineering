using System;
using System.Text;

using ClassBoxData.Exceptions;

namespace ClassBoxData.Models
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.LengthZeroOrNegativeException);
                }

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.WidthZeroOrNegativeException);
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeightZeroOrNegativeException);
                }

                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            double area = (2 * this.Length * this.Width) + this.CalculateLateralSurfaceArea();

            return area;
        }

        public double CalculateLateralSurfaceArea()
        {
            double lateralArea = 2 * this.Length * this.Height + 2 * this.Width * this.Height;

            return lateralArea;
        }

        public double CalculateVolume()
        {
            double volume = this.Length * this.Width * this.Height;

            return volume;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.CalculateSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.CalculateLateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {this.CalculateVolume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
