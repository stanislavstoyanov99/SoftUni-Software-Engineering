using _01Logger.Models.Contracts;

namespace _01Logger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
