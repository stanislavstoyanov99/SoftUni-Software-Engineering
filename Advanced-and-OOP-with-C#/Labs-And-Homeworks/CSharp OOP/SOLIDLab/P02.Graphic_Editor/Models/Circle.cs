using P02.Graphic_Editor.Interfaces;

namespace P02.Graphic_Editor.Models
{
    public class Circle : GraphicEditor
    {
        protected override void DrawShape(IShape shape)
        {
            var circle = shape as Circle;

            // Draw circle
        }
    }
}
