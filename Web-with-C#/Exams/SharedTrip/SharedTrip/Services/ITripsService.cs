namespace SharedTrip.Services
{
    using System.Collections.Generic;

    using ViewModels.Trips;

    public interface ITripsService
    {
        void Add(AddTripInputModel model);

        void AddUserToTrip(string userId, string tripId);

        bool DoesTripExist(string tripId);

        bool IsTripJoined(string userId, string tripId);

        IEnumerable<InfoViewModel> ListAllTrips();

        DetailsViewModel GetDetails(string id);
    }
}
