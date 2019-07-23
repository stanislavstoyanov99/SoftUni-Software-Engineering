using System;
using System.Linq;
using System.Reflection;

using _01Logger.Exceptions;
using _01Logger.Models.Contracts;

namespace _01Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            Type typeToCreate = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (typeToCreate == null)
            {
                throw new InvalidLayoutTypeException();
            }

            ILayout layout = (ILayout)Activator.CreateInstance(typeToCreate);

            return layout;
        }
    }
}
