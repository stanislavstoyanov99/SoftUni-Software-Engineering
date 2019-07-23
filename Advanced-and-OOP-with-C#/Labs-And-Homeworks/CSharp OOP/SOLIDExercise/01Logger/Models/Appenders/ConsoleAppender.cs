﻿using System;
using System.Globalization;

using _01Logger.Models.Contracts;
using _01Logger.Models.Enumerations;

namespace _01Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";
        private int messagesAppended;

        private ConsoleAppender()
        {
            this.messagesAppended = 0;
        }

        public ConsoleAppender(ILayout layout, Level level)
            :this()
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            string formattedMessage = String.Format(format,
                dateTime.ToString(dateFormat, CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            Console.WriteLine(formattedMessage);
            messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}," +
                $" Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.Level.ToString()}," +
                $" Messages appended: {this.messagesAppended}";
        }
    }
}
