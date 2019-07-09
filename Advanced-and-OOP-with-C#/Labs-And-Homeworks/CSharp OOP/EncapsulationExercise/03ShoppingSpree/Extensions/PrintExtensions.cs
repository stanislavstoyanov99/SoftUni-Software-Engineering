using System;
using System.Collections.Generic;

namespace _03ShoppingSpree.Extensions
{
    public static class PrintExtensions
    {
        public static string PrintAll<T>(this IList<T> collection)
        {
            return string.Join(Environment.NewLine, collection);
        }
    }
}
