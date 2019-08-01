namespace SoftUniRestaurant.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] arguments);

        string WriteSummary();
    }
}
