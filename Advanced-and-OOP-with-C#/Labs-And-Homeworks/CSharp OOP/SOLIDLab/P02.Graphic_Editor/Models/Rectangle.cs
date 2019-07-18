using P02.Graphic_Editor.Interfaces;

namespace P02.Graphic_Editor.Models
{
    public class Rectangle : GraphicEditor
    {
        protected override void DrawShape(IShape shape)
        {
            Rectangle rectangle = shape as Rectangle;

            // Draw Rectangle
        }
    }
}
