using P02.Graphic_Editor.Interfaces;

namespace P02.Graphic_Editor.Models
{
    public class Square : GraphicEditor
    {
        protected override void DrawShape(IShape shape)
        {
            Square square = shape as Square;

            // Draw square
        }
    }
}
