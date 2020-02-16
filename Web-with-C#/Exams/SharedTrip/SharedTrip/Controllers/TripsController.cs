namespace SharedTrip.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;
    using ViewModels.Trips;

    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        [HttpGet]
        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new AllTripsViewModel
            {
                Trips = this.tripsService.ListAllTrips()
            };

            return this.View(viewModel);
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
        public HttpResponse Add(AddTripInputModel model)
        {
            if (string.IsNullOrEmpty(model.StartPoint))
            {
                return this.View();
            }

            if (string.IsNullOrEmpty(model.EndPoint))
            {
                return this.View();
            }

            if (string.IsNullOrEmpty(model.DepartureTime))
            {
                return this.View();
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                return this.View();
            }

            if (model.Description.Length > 80)
            {
                return this.View();
            }

            this.tripsService.Add(model);

            return this.Redirect("/Trips/All");
        }

        [HttpGet]
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            // If user has already joined this trip
            if (this.tripsService.IsTripJoined(this.User, tripId))
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            this.tripsService.AddUserToTrip(this.User, tripId);

            return this.Redirect("/");
        }

        [HttpGet]
        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            // Check if the user tries to delete tripId in the query data
            if (string.IsNullOrEmpty(tripId))
            {
                return this.Redirect("/Trips/All");
            }

            var viewModel = this.tripsService.GetDetails(tripId);

            return this.View(viewModel);
        }
    }
}
