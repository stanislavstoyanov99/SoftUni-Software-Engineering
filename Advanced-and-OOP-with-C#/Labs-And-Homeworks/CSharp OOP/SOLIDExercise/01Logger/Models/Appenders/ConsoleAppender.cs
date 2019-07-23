using System;
using System.Globalization;

using _01Logger.Models.Contracts;
using _01Logger.Models.Enumerations;
using _01Logger.Models.Formats;

namespace _01Logger.Models.Appenders
{
    public class ConsoleAppender : Appender, IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public override int MessagesAppended { get; protected set; }

        public override void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            string formattedMessage = String.Format(format,
                dateTime.ToString(DateTimeFormat.FORMAT, CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            Console.WriteLine(formattedMessage);

            MessagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
