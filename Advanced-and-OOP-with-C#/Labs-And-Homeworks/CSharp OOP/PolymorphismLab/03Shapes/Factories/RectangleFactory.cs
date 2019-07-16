using Shapes.Models;

namespace Shapes.Factories
{
    public sealed class RectangleFactory
    {
        public Rectangle CreateRectangle(int width, int height)
        {
            Rectangle rectangle = new Rectangle(width, height);

            return rectangle;
        }
    }
}
