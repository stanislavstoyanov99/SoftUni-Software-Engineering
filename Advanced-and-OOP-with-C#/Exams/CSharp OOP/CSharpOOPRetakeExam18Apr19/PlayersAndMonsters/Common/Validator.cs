namespace PlayersAndMonsters.Common
{
    using System;
    public static class Validator
    {
        public static void ThrowIfIntegerIsBelowZero(int value, string message = null)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
