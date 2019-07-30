namespace CustomTestingFramework.TestRunner.Contracts
{
    using System.Collections.Generic;

    public interface ITestRunner
    {
        IReadOnlyCollection<string> Run(string assemblyPath);
    }
}
