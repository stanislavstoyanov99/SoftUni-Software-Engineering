namespace SharedTrip.Services
{
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;

    using Models;
    using ViewModels.Trips;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext dbContext;

        public TripsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(AddTripInputModel model)
        {
            var departureTimeAsDateTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = departureTimeAsDateTime,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description,
            };

            this.dbContext.Trips.Add(trip);
            this.dbContext.SaveChanges();
        }

        public void AddUserToTrip(string userId, string tripId)
        {
            var userTrip = new UserTrip
            {
                UserId = userId,
                TripId = tripId
            };

            this.dbContext.UserTrips.Add(userTrip);
            this.dbContext.SaveChanges();
        }

        public bool DoesTripExist(string tripId)
        {
            return this.dbContext.Trips.Any(x => x.Id == tripId);
        }

        public DetailsViewModel GetDetails(string id)
        {
            var viewModel = this.dbContext.Trips
                .Where(x => x.Id == id)
                .Select(x => new DetailsViewModel
                {
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Seats = x.Seats,
                    Description = x.Description
                })
                .FirstOrDefault();

            return viewModel;
        }

        public bool IsTripJoined(string userId, string tripId)
        {
            return this.dbContext.UserTrips
                .Any(x => x.UserId == userId && x.TripId == tripId);
        }

        public IEnumerable<InfoViewModel> ListAllTrips()
        {
            var allTrips = this.dbContext.Trips
                .Select(x => new InfoViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Seats = x.Seats
                })
                .ToList();

            return allTrips;
        }
    }
}
