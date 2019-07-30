namespace CustomTestingFramework.TestRunner
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using CustomTestingFramework.Utilities;
    using CustomTestingFramework.Attributes;
    using CustomTestingFramework.TestRunner.Contracts;

    public class TestRunner : ITestRunner
    {
        private readonly List<string> resultInfo;

        public TestRunner()
        {
            this.resultInfo = new List<string>();
        }

        public IReadOnlyCollection<string> ResultInfo
        {
            get => this.resultInfo.AsReadOnly();
        }

        public IReadOnlyCollection<string> Run(string assemblyPath)
        {
            // Find all classes which have specific custom attribute
            var testClasses = Assembly
                .LoadFile(assemblyPath)
                .GetTypes()
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(TestClassAttribute)))
                .ToList();

            foreach (var testClass in testClasses)
            {
                // Find all test methods using custom extension method HasAttribute
                var testMethods = testClass
                    .GetMethods()
                    .Where(x => x.HasAttribute<TestMethodAttribute>())
                    .ToList();

                var testClassInstace = Activator.CreateInstance(testClass);

                foreach (var testMethod in testMethods)
                {
                    try
                    {
                        testMethod.Invoke(testClassInstace, null);
                        this.resultInfo.Add($"Method: {testMethod.Name} - passed successfully!");
                    }
                    catch (TargetInvocationException ex)
                    {
                        this.resultInfo.Add($"Method: {testMethod.Name} failed - {ex.InnerException.Message}");
                    }
                }
            }

            return this.ResultInfo;
        }
    }
}
