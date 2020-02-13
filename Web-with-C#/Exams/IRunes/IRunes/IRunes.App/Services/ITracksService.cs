﻿namespace IRunes.App.Services
{
    using ViewModels.Tracks;

    public interface ITracksService
    {
        void Create(string albumId, string name, string link, decimal price);

        DetailsViewModel GetDetails(string albumId, string trackId);
    }
}
