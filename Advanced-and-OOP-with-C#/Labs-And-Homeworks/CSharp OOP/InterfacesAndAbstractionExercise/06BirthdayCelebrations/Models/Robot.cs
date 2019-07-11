using System;

using _06BirthdayCelebrations.Interfaces;

namespace _06BirthdayCelebrations.Models
{
    public class Robot : IIdentifiable
    {
        public string Id { get; private set; }
    }
}
