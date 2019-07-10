namespace _04PizzaCalories.Exceptions
{
    public sealed class ExceptionMessages
    {
        public const string InvalidTypeOfDoughException = "Invalid type of dough.";

        public const string InvalidWeightOfDoughException = "Dough weight should be in the range [1..200].";

        public const string InvalidToppingTypeException = "Cannot place {0} on top of your pizza.";

        public const string InvalidWeightOfToppingException = "{0} weight should be in the range [1..50].";

        public const string InvalidPizzaNameException = "Pizza name should be between 1 and 15 symbols.";

        public const string InvalidNumberOfToppingsException = "Number of toppings should be in range [0..10].";
    }
}
