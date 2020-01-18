namespace PetStore.Services.Utilities
{
    public static class ExceptionMessages
    {
        public const string InvalidBrandName =
            "Brand name cannot be more than {0} characters.";

        public const string BrandNameAlreadyExists =
            "Brand name {0} already exists.";

        public const string InvalidName =
            "Name cannot be null or whitespace!";

        public const string InvalidProfitValue =
            "Profit must be higher than zero and lower than 500%";

        public const string FoodDoesNotExist =
            "There is no such food with id {0} in the database!";

        public const string UserDoesNotExist =
            "There is no such user with id {0} in the database!";

        public const string ToyDoesNotExist =
            "There is no such toy with id {0} in the database!";

        public const string BreedDoesNotExist =
            "There is no such breed with id {0} in the database!";

        public const string CategoryDoesNotExist =
            "There is no such category with id {0} in the database!";

        public const string PetDoesNotExist =
            "There is no such pet with id {0} in the database!";

        public const string InvalidPetPrice =
            "Price of the pet cannot be less than zero.";
    }
}
