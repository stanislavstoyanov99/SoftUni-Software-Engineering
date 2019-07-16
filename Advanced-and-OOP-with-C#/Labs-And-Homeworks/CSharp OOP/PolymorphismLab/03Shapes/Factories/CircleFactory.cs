using Shapes.Models;

namespace Shapes.Factories
{
    public sealed class CircleFactory
    {
        public Circle CreateCircle(int radius)
        {
            Circle circle = new Circle(radius);

            return circle;
        }
    }
}
