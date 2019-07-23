using System;

using _01Logger.Exceptions;
using _01Logger.Models.Appenders;
using _01Logger.Models.Contracts;
using _01Logger.Models.Enumerations;
using _01Logger.Models.Files;

namespace _01Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
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

            IAppender appender;
            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile();
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidAppenderTypeException();
            }

            return appender;
        }
    }
}
