namespace Restaurant.Food.Desserts
{
    public class Cake : Dessert
    {
        private const decimal cakePrice = 5m;
        private const double grams = 250;
        private const double calories = 1000;

        public Cake(string name) 
            : base(name, cakePrice, grams, calories)
        {

        }
    }
}
