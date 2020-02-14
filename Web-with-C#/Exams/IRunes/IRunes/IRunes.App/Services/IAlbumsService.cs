namespace IRunes.App.Services
{
    using System.Collections.Generic;

    using ViewModels.Albums;

    public interface IAlbumsService
    {
        void Create(string name, string cover);

        // IList<T> GetAll<T>(Func<Album, T> selectFunc);

        IEnumerable<AlbumInfoViewModel> GetAll();

        DetailsViewModel GetDetails (string id);
    }
}
