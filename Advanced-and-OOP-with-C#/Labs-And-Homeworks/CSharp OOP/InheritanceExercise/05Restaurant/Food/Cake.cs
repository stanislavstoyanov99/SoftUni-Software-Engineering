namespace Restaurant.Food
{
    public class Cake : Dessert
    {
        private const double grams = 250;
        private const double calories = 1000;
        private const decimal cakePrice = 5m;

        public Cake(string name) 
            : base(name, cakePrice, grams, calories)
        {

        }
    }
}
