﻿using P03.Detail_Printer.Interfaces;

namespace P03.Detail_Printer.Models
{
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
