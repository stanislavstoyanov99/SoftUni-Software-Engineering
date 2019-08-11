using System;

using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        public Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;

            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Player's name cannot be null or a whitespace!");
                }

                this.name = value;
            }
        }
        public int LifePoints
        {
            get => this.lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }

                this.lifePoints = value;
            }
        }

        public IRepository<IGun> GunRepository { get; }

        public bool IsAlive => this.LifePoints > 0;

        public void TakeLifePoints(int points)
        {
            int newLifePoints = this.LifePoints - points;

            if (newLifePoints >= 0)
            {
                this.LifePoints = newLifePoints;
            }
            else
            {
                this.LifePoints = 0;
            }
        }
    }
}
