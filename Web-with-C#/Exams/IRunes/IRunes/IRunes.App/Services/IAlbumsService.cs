namespace IRunes.App.Services
{
    using System;
    using System.Collections.Generic;

    using Models;
    using ViewModels.Albums;

    public interface IAlbumsService
    {
        void Create(string name, string cover);

        IList<T> GetAll<T>(Func<Album, T> selectFunc);

        DetailsViewModel GetDetails (string id);
    }
}
