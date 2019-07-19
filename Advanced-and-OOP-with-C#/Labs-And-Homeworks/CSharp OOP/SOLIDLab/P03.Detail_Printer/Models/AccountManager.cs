using P03.Detail_Printer.Interfaces;

namespace P03.Detail_Printer.Models
{
    public class AccountManager : IEmployee
    {
        public AccountManager(string name)
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
