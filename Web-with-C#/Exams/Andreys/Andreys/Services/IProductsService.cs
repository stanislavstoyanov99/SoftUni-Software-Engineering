namespace Andreys.Services
{
    using System.Collections.Generic;

    using ViewModels.Products;

    public interface IProductsService
    {
        void Add(string name, string description, string imageUrl, string category, string gender, decimal price, string userId);

        IEnumerable<InfoViewModel> ListAllProducts(string userId);

        DetailsViewModel GetDetails(int id);

        void Delete(int id);
    }
}
