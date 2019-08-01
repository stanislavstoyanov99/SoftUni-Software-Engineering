namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly RestaurantController restaurantController;

        public CommandInterpreter(RestaurantController restaurantController)
        {
            this.restaurantController = restaurantController;
        }

        public string Read(string[] inputArgs)
        {
            string result = string.Empty;
            string commandName = inputArgs[0];

            switch (commandName)
            {
                case "AddFood":
                    string foodType = inputArgs[1];
                    string foodName = inputArgs[2];
                    decimal price = decimal.Parse(inputArgs[3]);

                    result = this.restaurantController.AddFood(foodType, foodName, price);
                    break;
                case "AddDrink":
                    string drinkType = inputArgs[1];
                    string drinkName = inputArgs[2];
                    int servingSize = int.Parse(inputArgs[3]);
                    string brand = inputArgs[4];

                    result = this.restaurantController.AddDrink(drinkType, drinkName, servingSize, brand);
                    break;
                case "AddTable":
                    string tableType = inputArgs[1];
                    int tableNumber = int.Parse(inputArgs[2]);
                    int capacity = int.Parse(inputArgs[3]);

                    result = this.restaurantController.AddTable(tableType, tableNumber, capacity);
                    break;
                case "ReserveTable":
                    int numberOfPeople = int.Parse(inputArgs[1]);

                    result = this.restaurantController.ReserveTable(numberOfPeople);
                    break;
                case "OrderFood":
                    int tableNumberForOrder = int.Parse(inputArgs[1]);
                    string foodNameForOrder = inputArgs[2];

                    result = this.restaurantController.OrderFood(tableNumberForOrder, foodNameForOrder);
                    break;
                case "OrderDrink":
                    int tableNumberForDrink = int.Parse(inputArgs[1]);
                    string drinkNameForOrder = inputArgs[2];
                    string drinkBrand = inputArgs[3];

                    result = this.restaurantController.OrderDrink(tableNumberForDrink, drinkNameForOrder, drinkBrand);
                    break;
                case "LeaveTable":
                    int tableNumberForLeaving = int.Parse(inputArgs[1]);

                    result = this.restaurantController.LeaveTable(tableNumberForLeaving);
                    break;
                case "GetFreeTablesInfo":
                    result = this.restaurantController.GetFreeTablesInfo();
                    break;
                case "GetOccupiedTablesInfo":
                    result = this.restaurantController.GetOccupiedTablesInfo();
                    break;
            }

            return result;
        }

        public string WriteSummary()
        {
            return this.restaurantController.GetSummary();
        }
    }
}
