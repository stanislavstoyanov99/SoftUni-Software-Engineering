namespace IRunes.App.Services
{
    using System.Linq;

    using Data;
    using Models;
    using ViewModels.Tracks;

    public class TracksService : ITracksService
    {
        private readonly RunesDbContext db;

        public TracksService(RunesDbContext db)
        {
            this.db = db;
        }

        public void Create(string albumId, string name, string link, decimal price)
        {
            var track = new Track
            {
                Name = name,
                Link = link,
                Price = price,
                AlbumId = albumId
            };

            this.db.Tracks.Add(track);

            var allTrackPricesSum = this.db.Tracks
                .Where(x => x.AlbumId == albumId)
                .Sum(x => x.Price) + price;

            var album = this.db.Albums.Find(albumId);

            album.Price = allTrackPricesSum * 0.87M;

            this.db.SaveChanges();
        }

        public DetailsViewModel GetDetails(string trackId)
        {
            var viewModel = this.db.Tracks
                .Where(x => x.Id == trackId)
                .Select(x => new DetailsViewModel
                {
                    AlbumId = x.AlbumId,
                    Name = x.Name,
                    Price = x.Price,
                    Link = x.Link
                })
                .FirstOrDefault();

            return viewModel;
        }
    }
}
