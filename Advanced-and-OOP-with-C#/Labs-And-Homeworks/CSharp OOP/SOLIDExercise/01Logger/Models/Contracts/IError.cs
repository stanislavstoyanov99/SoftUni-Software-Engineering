using System;

using _01Logger.Models.Enumerations;

namespace _01Logger.Models.Contracts
{
    public interface IError
    {
        Level Level { get; }

        DateTime DateTime { get; }

        string Message { get; }
    }
}
