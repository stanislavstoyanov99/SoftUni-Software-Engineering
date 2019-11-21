namespace ProductShop
{
    using System.Linq;

    using AutoMapper;

    using ProductShop.Models;
    using ProductShop.Dtos.Export;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, ProductInfoDto>()
                .ForMember(x => x.Seller, y => y.MapFrom(x => x.Seller.FirstName + " " + x.Seller.LastName));

            this.CreateMap<User, UsersInfoDto>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(x => x.ProductsSold.Where(x => x.Buyer != null)));

            this.CreateMap<Product, SoldProductsDto>()
                .ForMember(x => x.BuyerFirstName, y => y.MapFrom(x => x.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName, y => y.MapFrom(x => x.Buyer.LastName));

            this.CreateMap<Category, CategoriesInfoDto>()
                .ForMember(x => x.Category, y => y.MapFrom(x => x.Name))
                .ForMember(x => x.ProductsCount, y => y.MapFrom(x => x.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, y => y.MapFrom(x => x.CategoryProducts.Average(x => x.Product.Price).ToString("f2")))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(x => x.CategoryProducts.Sum(x => x.Product.Price).ToString("f2")));

            // Problem 08 - maps
            this.CreateMap<Product, ProductDto>();

            this.CreateMap<User, SoldProductsInfoDto>()
                .ForMember(x => x.Count, y => y.MapFrom(x => x.ProductsSold.Count(x => x.Buyer != null)))
                .ForMember(x => x.Products, y => y.MapFrom(x => x.ProductsSold.Where(x => x.Buyer != null)));

            this.CreateMap<User, UsersDto>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(x => x));

            // Map between DTO-s
            this.CreateMap<UsersDto[], UserOutputDto>()
                .ForMember(x => x.UsersCount, y => y.MapFrom(x => x.Length))
                .ForMember(x => x.Users, y => y.MapFrom(x => x));
        }
    }
}
