namespace SoftUniRestaurant.Core
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using SoftUniRestaurant.Factories;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;

    public class RestaurantController
    {
        private readonly List<IFood> menu;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        private readonly DrinkFactory drinkFactory;
        private readonly FoodFactory foodFactory;
        private readonly TableFactory tableFactory;

        private decimal totalIncome;

        public RestaurantController(
            DrinkFactory drinkFactory,
            FoodFactory foodFactory,
            TableFactory tableFactory)
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

            this.drinkFactory = drinkFactory;
            this.foodFactory = foodFactory;
            this.tableFactory = tableFactory;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = this.foodFactory.CreateFood(type, name, price);
            this.menu.Add(food);

            string result = $"Added {name} ({food.GetType().Name}) with price {price:F2} to the pool";

            return result;
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);
            this.drinks.Add(drink);

            string result = $"Added {name} ({brand}) to the drink pool";

            return result;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = this.tableFactory.CreateTable(type, tableNumber, capacity);
            this.tables.Add(table);

            string result = $"Added table number {tableNumber} in the restaurant";

            return result;
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable foundTable = this.tables
                .FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (foundTable != null)
            {
                foundTable.Reserve(numberOfPeople);

                return $"Table {foundTable.TableNumber} has been reserved for {numberOfPeople} people";
            }
            else
            {
                return $"No available table for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable foundTable = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);

            if (foundTable == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IFood foundFood = this.menu
                .FirstOrDefault(f => f.Name == foodName);

            if (foundFood == null)
            {
                return $"No {foodName} in the menu";
            }

            foundTable.OrderFood(foundFood);

            return $"Table {foundTable.TableNumber} ordered {foundFood.Name}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable foundTable = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);

            if (foundTable == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IDrink foundDrink = this.drinks
                .FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (foundDrink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            foundTable.OrderDrink(foundDrink);

            return $"Table {foundTable.TableNumber} ordered {foundDrink.Name} {foundDrink.Brand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable foundTable = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal tableBill = foundTable.GetBill();
            foundTable.Clear();

            this.totalIncome += tableBill;

            return $"Table: {foundTable.TableNumber}" + Environment.NewLine + $"Bill: {tableBill:F2}";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables)
            {
                if (table.IsReserved == false)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables)
            {
                if (table.IsReserved == true)
                {
                    sb.AppendLine(table.GetOccupiedTableInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {totalIncome:F2}lv";
        }
    }
}
