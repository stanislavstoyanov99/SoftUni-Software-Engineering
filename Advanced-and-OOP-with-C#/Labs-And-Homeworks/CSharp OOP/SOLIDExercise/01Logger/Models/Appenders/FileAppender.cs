using System;

using _01Logger.Models.Contracts;
using _01Logger.Models.Enumerations;
using _01Logger.Models.Files;

namespace _01Logger.Models.Appenders
{
    public class FileAppender : Appender, IAppender
    {
        public FileAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;

            this.File = new LogFile();
        }

        public IFile File { get; private set; }

        public override int MessagesAppended { get; protected set; }

        public override void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error) + Environment.NewLine;

            System.IO.File.AppendAllText(this.File.Path, formattedMessage);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
