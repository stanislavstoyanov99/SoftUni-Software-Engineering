using System;

using _06BirthdayCelebrations.Interfaces;

namespace _06BirthdayCelebrations.Models
{
    public class Citizen : IIdentifiable, IBirthdable
    {
        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public string Name { get; private set; }
    }
}
