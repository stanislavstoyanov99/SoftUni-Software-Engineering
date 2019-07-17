using _08MilitaryElite.Models;

namespace _08MilitaryElite.Factories
{
    public class PrivateFactory
    {
        public Private CreatePrivate(string id, string firstName, string lastName, decimal salary)
        {
            Private soldier = new Private(id, firstName, lastName, salary);

            return soldier;
        }
    }
}
