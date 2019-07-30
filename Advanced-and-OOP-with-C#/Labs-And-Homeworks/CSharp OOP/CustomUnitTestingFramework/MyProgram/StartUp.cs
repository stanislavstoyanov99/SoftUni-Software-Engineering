namespace MyProgram
{
    using CustomTestingFramework.Extensions;
    using CustomTestingFramework.TestRunner;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var runner = new TestRunner();

            var resultSet = runner.Run(@"D:\СофтУни - Курсове\C# Advanced & C# OOP - May 19\C Sharp OOP\CustomUnitTestingFramework\CustomTestingFramework.Tests\bin\Debug\netcoreapp2.1\CustomTestingFramework.Tests.dll");

            resultSet.Print();
        }
    }
}
