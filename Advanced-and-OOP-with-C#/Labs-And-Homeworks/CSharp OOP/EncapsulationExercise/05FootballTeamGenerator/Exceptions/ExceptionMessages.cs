namespace _05FootballTeamGenerator.Exceptions
{
    public sealed class ExceptionMessages
    {
        public const string EmptyNameException = "A name should not be empty.";

        public const string InvalidStatException = "{0} should be between {1} and {2}.";

        public const string MissingPlayerException = "Player {0} is not in {1} team.";

        public const string MissingTeamException = "Team {0} does not exist.";
    }
}
