using _01Logger.Models.Contracts;
using _01Logger.Models.Enumerations;

namespace _01Logger.Models.Appenders
{
    public abstract class Appender : IAppender
    {
        public ILayout Layout { get; protected set; }

        public Level Level { get; protected set; }

        public abstract int MessagesAppended { get; protected set; }

        public abstract void Append(IError error);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}," +
                $" Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.Level.ToString()}," +
                $" Messages appended: {this.MessagesAppended}";
        }
    }
}
