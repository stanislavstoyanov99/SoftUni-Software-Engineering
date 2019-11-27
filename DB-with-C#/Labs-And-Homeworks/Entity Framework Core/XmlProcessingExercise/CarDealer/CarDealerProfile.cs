namespace CarDealer
{
    using AutoMapper;

    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplier, Supplier>();
            this.CreateMap<ImportPart, Part>();
            this.CreateMap<ImportCar, Car>();
        }
    }
}