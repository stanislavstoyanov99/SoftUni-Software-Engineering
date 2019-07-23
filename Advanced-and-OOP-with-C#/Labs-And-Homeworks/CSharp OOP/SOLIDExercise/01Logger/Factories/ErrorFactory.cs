using System;
using System.Globalization;

using _01Logger.Exceptions;
using _01Logger.Models.Contracts;
using _01Logger.Models.Enumerations;
using _01Logger.Models.Errors;
using _01Logger.Models.Formats;

namespace _01Logger.Factories
{
    public class ErrorFactory
    {
        public IError GetError(string dateString, string levelString, string message)
        {
            Level level;

            bool isParsed = Enum.TryParse<Level>(levelString, out level);

            if (!isParsed)
            {
                throw new InvalidLevelTypeException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString,
                    DateTimeFormat.FORMAT, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new InvalidDateFormatException();
            }

            IError error = new Error(dateTime, message, level);

            return error;
        }
    }
}
