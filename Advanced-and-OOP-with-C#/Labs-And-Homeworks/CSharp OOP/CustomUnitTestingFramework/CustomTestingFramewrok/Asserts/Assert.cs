namespace CustomTestingFramework.Asserts
{
    using System;
    using CustomTestingFramework.Exceptions;

    public static class Assert
    {
        public static bool AreEqual(object a, object b)
        {
            if (!a.Equals(b))
            {
                throw new InvalidValueException();
            }

            return true;
        }

        public static bool AreNotEqual(object a, object b)
        {
            if (a.Equals(b))
            {
                throw new InvalidValueException();
            }

            return false;
        }

        public static void Throws<T>(Func<bool> condition)
            where T : Exception
        {
            try
            {
                condition.Invoke();
            }
            catch (T)
            {
                throw;
            }
        }
    }
}
