using _01Logger.Exceptions;
using _01Logger.Models.Contracts;
using _01Logger.Models.Layouts;

namespace _01Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            ILayout layout;

            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new InvalidLayoutTypeException();
            }

            return layout;
        }
    }
}
