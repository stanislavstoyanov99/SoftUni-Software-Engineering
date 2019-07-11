using System;
using System.Collections.Generic;

namespace _05BorderControl.Extentions
{
    public static class PrintFakeIdsExtention
    {
        public static string PrintAll<T>(this List<T> collection)
        {
           return string.Join(Environment.NewLine, collection);
        }
    }
}
