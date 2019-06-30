namespace PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            bool result = false;

            if (this.TopLeft.CoordinateX <= point.CoordinateX
                && this.BottomRight.CoordinateX >= point.CoordinateX
                && this.TopLeft.CoordinateY <= point.CoordinateY
                && this.BottomRight.CoordinateY >= point.CoordinateY)
            {
                result = true;
            }

            return result;
        }
    }
}
