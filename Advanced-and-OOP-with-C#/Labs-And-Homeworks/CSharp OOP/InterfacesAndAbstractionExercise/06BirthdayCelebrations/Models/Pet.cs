using System;

using _06BirthdayCelebrations.Interfaces;

namespace _06BirthdayCelebrations.Models
{
    public class Pet : IBirthdable
    {
        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
