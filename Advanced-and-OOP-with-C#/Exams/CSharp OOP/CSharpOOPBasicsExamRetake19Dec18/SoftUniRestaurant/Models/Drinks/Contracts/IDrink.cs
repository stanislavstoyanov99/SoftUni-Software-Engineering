using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Models.Drinks.Contracts
{
    public interface IDrink : IFood
    {
        string Brand { get; }
    }
}
