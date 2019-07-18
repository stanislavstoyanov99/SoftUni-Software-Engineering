using P02.Graphic_Editor.Interfaces;

namespace P02.Graphic_Editor.Models
{
    // Template method pattern

    public abstract class GraphicEditor : IGraphicEditor
    {
        public void Draw(IShape shape)
        {
            this.DrawShape(shape);
        }

        protected abstract void DrawShape(IShape shape);
    }
}
