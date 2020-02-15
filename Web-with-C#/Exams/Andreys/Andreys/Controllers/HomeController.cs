namespace Andreys.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;
    using ViewModels.Products;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.View();
            }

            var viewModel = new AllProductsViewModel
            {
                Products = this.productsService.ListAllProducts(this.User)
            };

            return this.View(viewModel, "Home");
        }

        [HttpGet("/Home/Home")]
        public HttpResponse Home()
        {
            return this.Index();
        }
    }
}
