namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public const string InvalidPlayerNameException = 
            "Player's username cannot be null or an empty string.";

        public const string InvalidPlayerHealthException =
            "Player's health bonus cannot be less than zero.";

        public const string InvalidDamagePointsException =
            "Damage points cannot be less than zero.";

        public const string InvalidCardNameException =
            "Card's name cannot be null or an empty string.";

        public const string InvalidCardDamagePointsException =
            "Card's damage points cannot be less than zero.";

        public const string InvalidCardHPException =
            "Card's HP cannot be less than zero.";

        public const string PlayerDeadException =
            "Player is dead!";

        public const string PlayerNotFoundException =
            "Player cannot be null";

        public const string PlayerAllreadyExistsException =
            "Player {0} already exists!";

        public const string CardNotFoundException =
            "Card cannot be null!";

        public const string CardAllreadyExistsException =
            "Card {0} already exists!";
    }
}
