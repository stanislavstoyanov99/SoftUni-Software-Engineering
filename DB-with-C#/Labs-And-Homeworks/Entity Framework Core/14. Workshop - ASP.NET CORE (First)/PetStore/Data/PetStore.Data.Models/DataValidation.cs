﻿namespace PetStore.Data.Models
{
    public static class DataValidation
    {
        public const int NameMaxLength = 30;

        public static class Category
        {
            public const int DescriptionMaxLength = 1000;
        }

        public static class Pet
        {
            public const int DescriptionMaxLength = 1500;
        }

        public static class Toy
        {
            public const int DescriptionMaxLength = 1200;
        }

        public static class User
        {
            public const int EmailMaxLength = 100;
        }
    }
}
