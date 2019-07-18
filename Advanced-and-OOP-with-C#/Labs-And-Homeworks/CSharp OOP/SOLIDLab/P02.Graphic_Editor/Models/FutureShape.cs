using P02.Graphic_Editor.Interfaces;

namespace P02.Graphic_Editor.Models
{
    public class FutureShape : GraphicEditor
    {
        protected override void DrawShape(IShape shape)
        {
            var futureShape = shape as FutureShape;

            // Draw future shape
        }
    }
}
