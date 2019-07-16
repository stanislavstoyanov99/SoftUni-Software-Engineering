using Shapes.Exceptions;

namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height
        {
            get => this.height;
            private set
            {
                ValidateValue(value);

                this.height = value;
            }
        }

        public int Width
        {
            get => this.width;
            private set
            {
                ValidateValue(value);

                this.width = value;
            }
        }

        public override double CalculateArea()
        {
            double area = this.Width * this.Height;

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public sealed override string Draw()
        {
            return base.Draw() + "Rectangle";
        }

        private void ValidateValue(int value)
        {
            if (value <= 0)
            {
                throw new NegativeValueException();
            }
        }
    }
}
