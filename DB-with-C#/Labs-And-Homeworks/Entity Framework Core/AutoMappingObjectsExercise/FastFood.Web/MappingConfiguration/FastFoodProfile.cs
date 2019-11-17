namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using System.Linq;

    using Models;
    using ViewModels.Positions;
    using FastFood.Web.ViewModels.Items;
    using FastFood.Web.ViewModels.Orders;
    using FastFood.Web.ViewModels.Employees;
    using FastFood.Web.ViewModels.Categories;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(src => src.PositionId, dest => dest.MapFrom(src => src.Id));

            //Orders - WHY??
            this.CreateMap<CreateOrderInputModel, Order>();

            this.CreateMap<CreateOrderViewModel, Order>()
                .ForMember(src => src.OrderItems, dest => dest.MapFrom(src => src.Items))
                .ForMember(src => src.EmployeeId, dest => dest.MapFrom(src => src.Employees.Select(e => e)));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(src => src.OrderId, dest => dest.MapFrom(src => src.Id))
                .ForMember(src => src.Customer, dest => dest.MapFrom(src => src.Customer))
                .ForMember(src => src.Employee, dest => dest.MapFrom(src => src.Employee.Name))
                .ForMember(src => src.DateTime, dest => dest.MapFrom(src => src.DateTime.ToString()));

            //Items
            this.CreateMap<CreateItemInputModel, Item>()
                .ForMember(src => src.Name, dest => dest.MapFrom(src => src.Name))
                .ForMember(src => src.Price, dest => dest.MapFrom(src => src.Price))
                .ForMember(src => src.CategoryId, dest => dest.MapFrom(src => src.CategoryId));

            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(src => src.CategoryId, dest => dest.MapFrom(src => src.Id));

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(src => src.Name, dest => dest.MapFrom(src => src.Name))
                .ForMember(src => src.Price, dest => dest.MapFrom(src => src.Price))
                .ForMember(src => src.Category, dest => dest.MapFrom(src => src.Category));

            //Employees - WHY??
            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(src => src.Name, dest => dest.MapFrom(src => src.Name))
                .ForMember(src => src.Age, dest => dest.MapFrom(src => src.Age))
                .ForMember(src => src.Address, dest => dest.MapFrom(src => src.Address))
                .ForMember(src => src.Position, dest => dest.MapFrom(src => src.Position.Name));

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(src => src.Name, dest => dest.MapFrom(src => src.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>()
                .ForMember(src => src.Name, dest => dest.MapFrom(src => src.Name));
        }
    }
}
