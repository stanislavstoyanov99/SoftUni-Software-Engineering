using System;
using System.Linq;
using System.Reflection;

using _01Logger.Exceptions;
using _01Logger.Models.Contracts;
using _01Logger.Models.Enumerations;

namespace _01Logger.Factories
{
    public class AppenderFactory
    {
        private readonly LayoutFactory layoutFactory;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelString)
        {
            Level level;
            bool isParsed = Enum.TryParse<Level>(levelString, out level);

            if (!isParsed)
            {
                throw new InvalidLevelTypeException();
            }

            ILayout layout = this.layoutFactory.GetLayout(layoutType);

            Type appenderToCreate = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == appenderType);

            if (appenderToCreate == null)
            {
                throw new InvalidAppenderTypeException();
            }

            object[] args = new object[]
            {
                layout,
                level,
            };

            IAppender appender = (IAppender)Activator.CreateInstance(appenderToCreate, args);

            return appender;
        }
    }
}
