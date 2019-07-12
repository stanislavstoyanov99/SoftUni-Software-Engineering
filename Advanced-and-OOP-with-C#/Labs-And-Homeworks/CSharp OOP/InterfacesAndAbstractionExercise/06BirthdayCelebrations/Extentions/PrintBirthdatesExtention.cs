using System;
using System.Collections.Generic;

namespace _06BirthdayCelebrations.Extentions
{
    public static class PrintBirthdatesExtention
    {
        public static string PrintAll<T>(this List<T> collection)
        {
            return string.Join(Environment.NewLine, collection);
        }
    }
}
