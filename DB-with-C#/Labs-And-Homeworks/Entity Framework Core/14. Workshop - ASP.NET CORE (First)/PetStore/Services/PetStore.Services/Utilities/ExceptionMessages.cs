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
            "There is no such food with given id in the database!";

        public const string UserDoesNotExist =
            "There is no such user with given id in the database!";
    }
}
