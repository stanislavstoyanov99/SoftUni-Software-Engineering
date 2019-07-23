using System;
using System.Globalization;

using _01Logger.Exceptions;
using _01Logger.Models.Contracts;
using _01Logger.Models.Enumerations;
using _01Logger.Models.Errors;

namespace _01Logger.Factories
{
    public class ErrorFactory
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

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
                dateTime = DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new InvalidDateFormatException();
            }

            return new Error(dateTime, message, level);
        }
    }
}
