namespace IRunes.App.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Data;
    using Models;
    using ViewModels.Albums;

    public class AlbumsService : IAlbumsService
    {
        private readonly RunesDbContext db;

        public AlbumsService(RunesDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0.0m
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public IEnumerable<AlbumInfoViewModel> GetAll()
        {
            var allAlbums = this.db.Albums
                .Select(x => new AlbumInfoViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            return allAlbums;
        }

        /* Interesting way
        public IList<T> GetAll<T>(Func<Album, T> selectFunc)
        {
            var allAlbums = this.db.Albums
                .Select(selectFunc)
                .ToList();

            return allAlbums;
        }
        */

        public DetailsViewModel GetDetails(string id)
        {
            var viewModel = this.db.Albums
                .Where(x => x.Id == id)
                .Select(x => new DetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cover = x.Cover,
                    Price = x.Price,
                    Tracks = x.Tracks.Select(t => new TrackInfoViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                    .ToList()
                })
                .FirstOrDefault();

            return viewModel;
        }
    }
}
