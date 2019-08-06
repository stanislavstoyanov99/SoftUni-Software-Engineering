namespace MXGP.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] inputArgs);
    }
}
