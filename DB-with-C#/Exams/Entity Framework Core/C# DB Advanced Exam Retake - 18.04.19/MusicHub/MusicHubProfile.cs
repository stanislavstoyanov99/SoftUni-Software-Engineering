namespace MusicHub
{
    using AutoMapper;

    using System;
    using System.Globalization;

    using MusicHub.Data.Models;
    using MusicHub.DataProcessor.ImportDtos;

    public class MusicHubProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public MusicHubProfile()
        {
            this.CreateMap<ImportProducerDto, Producer>();

            this.CreateMap<ImportAlbumDto, Album>()
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(
                    x => DateTime.ParseExact(x.ReleaseDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
