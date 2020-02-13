namespace IRunes.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;
    using ViewModels.Albums;

    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        [HttpGet]
        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new AllAlbumsViewModel
            {
                Albums = this.albumsService.GetAll(x => new AlbumInfoViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel inputModel)
        {
            if (inputModel.Name?.Length < 4 || inputModel.Name?.Length > 20)
            {
                return this.Redirect("/Albums/Create");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Cover))
            {
                return this.Error("Cover is required.");
            }

            this.albumsService.Create(inputModel.Name, inputModel.Cover);

            return this.Redirect("/Albums/All");
        }

        [HttpGet]
        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.albumsService.GetDetails(id);

            return this.View(viewModel);
        }
    }
}
