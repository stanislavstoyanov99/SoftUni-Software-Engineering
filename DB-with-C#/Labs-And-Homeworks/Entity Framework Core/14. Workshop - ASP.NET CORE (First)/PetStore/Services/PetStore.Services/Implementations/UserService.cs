﻿namespace PetStore.Services.Implementations
{
    using System;
    using System.Linq;

    using Utilities;

    using Data;
    using Data.Models;

    public class UserService : IUserService
    {
        private readonly PetStoreDbContext data;

        public UserService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Register(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.InvalidName);
            }

            var user = new User()
            {
                Name = name,
                Email = email
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        public bool Exists(int userId)
        {
            return this.data.Users.Any(u => u.Id == userId);
        }
    }
}
