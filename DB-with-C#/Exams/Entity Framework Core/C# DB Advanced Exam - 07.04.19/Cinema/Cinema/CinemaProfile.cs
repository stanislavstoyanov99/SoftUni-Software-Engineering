namespace Cinema
{
    using System;
    using System.Globalization;

    using AutoMapper;

    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;

    public class CinemaProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public CinemaProfile()
        {
            this.CreateMap<ImportHallWithSeatsDto, Hall>();

            this.CreateMap<ImportProjectionsDto, Projection>()
                .ForMember(x => x.DateTime, y => y.MapFrom(
                    x => DateTime.ParseExact(x.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)));
        }
    }
}
