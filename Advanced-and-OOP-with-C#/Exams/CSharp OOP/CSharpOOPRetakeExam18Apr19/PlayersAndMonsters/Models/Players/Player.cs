namespace PlayersAndMonsters.Models.Players
{
    using System;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerNameException);
                }

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                Validator.ThrowIfIntegerIsBelowZero(
                    value,
                    ExceptionMessages.InvalidPlayerHealthException);

                this.health = value;
            }
        }

        public bool IsDead => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfIntegerIsBelowZero(
                damagePoints,
                ExceptionMessages.InvalidDamagePointsException);

            int newHealth = this.Health - damagePoints;

            if (newHealth >= 0)
            {
                this.Health = newHealth;
            }
            else
            {
                this.Health = 0;
            }
        }
    }
}
