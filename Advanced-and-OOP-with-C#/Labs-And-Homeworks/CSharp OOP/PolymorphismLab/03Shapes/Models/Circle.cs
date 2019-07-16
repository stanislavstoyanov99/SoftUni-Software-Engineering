using System;

using Shapes.Exceptions;

namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            private set
            {
                if (value <= 0)
                {
                    throw new NegativeValueException();
                }

                this.radius = value;
            }
        }

        public override double CalculateArea()
        {
            double area = Math.PI * this.Radius * this.Radius;

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public sealed override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
