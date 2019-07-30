namespace CustomTestingFramework.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class ExtensionMethods
    {
        public static void Print(this IReadOnlyCollection<string> collection)
        {
            Console.WriteLine(string.Join(Environment.NewLine, collection));
        }
    }
}
