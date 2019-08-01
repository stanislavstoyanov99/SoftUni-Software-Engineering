namespace SoftUniRestaurant.Exceptions
{
    public static class ExceptionMessages
    {
        public const string InvalidNameException
            = "Name cannot be null or white space!";

        public const string InvalidServingSizeException
            = "Serving size cannot be less or equal to zero";

        public const string InvalidPriceException
            = "Price cannot be less or equal to zero!";

        public const string InvalidBrandException
            = "Brand cannot be null or white space!";

        public const string InvalidCapacityException
            = "Capacity has to be greater than 0";

        public const string InvalidNumberOfPeopleException
            = "Cannot place zero or less people!";
    }
}
