
namespace SoftUniRestaurant
{
    using SoftUniRestaurant.Core;
    using SoftUniRestaurant.Core.Contracts;
    using SoftUniRestaurant.Factories;

    public class StartUp
    {
        public static void Main()
        {
            DrinkFactory drinkFactory = new DrinkFactory();
            FoodFactory foodFactory = new FoodFactory();
            TableFactory tableFactory = new TableFactory();

            RestaurantController restaurantController = new RestaurantController(
                drinkFactory,
                foodFactory,
                tableFactory);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(restaurantController);

            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
