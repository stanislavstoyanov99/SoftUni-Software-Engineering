namespace ProductShop
{
    using AutoMapper;

    using ProductShop.Models;
    using ProductShop.Dtos.Import;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUser, User>();
            this.CreateMap<ImportProduct, Product>();
        }
    }
}
