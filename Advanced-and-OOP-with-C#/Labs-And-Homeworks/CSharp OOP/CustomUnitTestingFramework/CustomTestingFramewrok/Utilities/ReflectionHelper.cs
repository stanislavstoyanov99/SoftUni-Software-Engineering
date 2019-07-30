namespace CustomTestingFramework.Utilities
{
    using System;
    using System.Reflection;

    public static class ReflectionHelper
    {
        public static bool HasAttribute<T>(this MemberInfo mi)
            where T : Attribute
        {
            bool hasAttribute = mi.GetCustomAttribute<T>() != null;

            return hasAttribute;
        }
    }
}
