using System;

namespace Prototype
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            // Initialize with default sandwiches
            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", string.Empty, "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", string.Empty, string.Empty, "Peanut Butter, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            // Adding custom sandwiches
            sandwichMenu["LoadedBLT"] = new Sandwich("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives");
            sandwichMenu["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey, Ham, Salami", "Provolene", "Lettuce, Onion");
            sandwichMenu["Vegetarian"] = new Sandwich("Wheat", string.Empty, string.Empty, "Lettuce, Onion, Tomato, Olives, Spinach");

            // Clone sandwiches
            Sandwich clonedBLT = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich clonedThreeMeatCombo = sandwichMenu["ThreeMeatCombo"].Clone() as Sandwich;
            Sandwich clonedVegetarian = sandwichMenu["Vegetarian"].Clone() as Sandwich;
            Sandwich clonedTurkey = sandwichMenu["Turkey"].Clone() as Sandwich;
        }
    }
}
