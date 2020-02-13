namespace IRunes.App.Controllers
{
    using IRunes.App.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    using ViewModels.Tracks;

    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        [HttpGet]
        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CreateTrackViewModel
            {
                AlbumId = albumId
            };

            return this.View(viewModel);

        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel inputModel)
        {
            if (inputModel.Name?.Length < 4 || inputModel.Name?.Length > 20)
            {
                return this.Redirect($"/Tracks/Create?albumId={inputModel.AlbumId}");
            }

            this.tracksService.Create(inputModel.AlbumId, inputModel.Name, inputModel.Link, inputModel.Price);

            return this.Redirect($"/Albums/Details?id={inputModel.AlbumId}");
        }

        [HttpGet]
        public HttpResponse Details(string albumId, string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.tracksService.GetDetails(albumId, trackId);

            return this.View(viewModel);
        }
    }
}
