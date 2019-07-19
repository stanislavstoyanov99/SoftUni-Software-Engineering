using System;
using System.Collections.Generic;

using P03.Detail_Printer.Interfaces;

namespace P03.Detail_Printer.Models
{
    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents)
            : this(name)
        {
            this.Documents = new List<string>(documents);
        }

        private Manager(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<string> Documents { get; private set; }

        public override string ToString()
        {
            return this.Name + Environment.NewLine +
                string.Join(Environment.NewLine, this.Documents);
        }
    }
}
