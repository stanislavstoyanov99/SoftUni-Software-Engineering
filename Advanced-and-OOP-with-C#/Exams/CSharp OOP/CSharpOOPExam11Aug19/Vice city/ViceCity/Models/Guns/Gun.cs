﻿namespace ViceCity.Models.Guns
{
    using System;

    using ViceCity.Utilities.Messages;
    using ViceCity.Models.Guns.Contracts;

    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => this.bulletsPerBarrel;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBulletsCount);
                }

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => this.totalBullets;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTotalBulletsCount);
                }

                this.totalBullets = value;
            }
        }

        public bool CanFire => this.BulletsPerBarrel > 0;

        public abstract int Fire();
    }
}
