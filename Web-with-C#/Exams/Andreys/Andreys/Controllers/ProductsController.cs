namespace Andreys.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;
    using ViewModels.Products;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddProductInputModel model)
        {
            if (model.Name?.Length < 4 || model.Name?.Length > 20)
            {
                return this.Redirect("/Products/Add");
            }

            if (model.Description?.Length > 10)
            {
                return this.Redirect("/Products/Add");
            }

            if (model.Price <= 0)
            {
                return this.Error("Price should be a positive number");
            }

            if (string.IsNullOrEmpty(model.ImageUrl))
            {
                return this.Redirect("/Products/Add");
            }

            this.productsService
                .Add(model.Name, model.Description, model.ImageUrl, model.Category, model.Gender, model.Price, this.User);

            return this.Redirect("/Home/Home");
        }

        [HttpGet]
        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.productsService.GetDetails(id);

            return this.View(viewModel);
        }

        [HttpGet]
        public HttpResponse Delete(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productsService.Delete(id);
            return this.Redirect("/Home/Home");
        }
    }
}
