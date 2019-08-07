namespace MXGP.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using MXGP.Core.Contracts;
    using MXGP.Factories;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Races;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories;
    using MXGP.Repositories.Contracts;
    using MXGP.Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        //private MotorcycleFactory motorcycleFactory;

        private readonly IRepository<IMotorcycle> motorcycleRepository;

        private readonly IRepository<IRace> raceRepository;

        private readonly IRepository<IRider> riderRepository;

        public ChampionshipController()
        {
            //this.motorcycleFactory = motorcycleFactory;

            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
            this.riderRepository = new RiderRepository();
        }

        public string CreateRider(string riderName)
        {
            IRider riderFound = this.riderRepository.GetByName(riderName);

            if (riderFound != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists,
                    riderName));
            }

            riderFound = new Rider(riderName);

            this.riderRepository.Add(riderFound);

            return string.Format(OutputMessages.RiderCreated, riderFound.Name);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle foundMotorcycle = this.motorcycleRepository
                .GetByName(model);

            if (foundMotorcycle != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists,
                    model));
            }

            if (type == "Power")
            {
                foundMotorcycle = new PowerMotorcycle(model, horsePower);
            }
            else if (type == "Speed")
            {
                foundMotorcycle = new SpeedMotorcycle(model, horsePower);
            }

            this.motorcycleRepository.Add(foundMotorcycle);

            return string.Format(OutputMessages.MotorcycleCreated,
                foundMotorcycle.GetType().Name, foundMotorcycle.Model);
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider foundRider = this.riderRepository.GetByName(riderName);

            if (foundRider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound,
                    riderName));
            }

            IMotorcycle foundMotorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            if (foundMotorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound,
                    motorcycleModel));
            }

            foundRider.AddMotorcycle(foundMotorcycle);

            return string.Format(OutputMessages.MotorcycleAdded,
                foundRider.Name, foundMotorcycle.Model);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace foundRace = this.raceRepository.GetByName(raceName);

            if (foundRace == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound,
                    raceName));
            }

            IRider foundRider = this.riderRepository.GetByName(riderName);

            if (foundRider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound,
                    riderName));
            }

            foundRace.AddRider(foundRider);

            return string.Format(OutputMessages.RiderAdded,
                foundRider.Name, foundRace.Name);
        }

        public string CreateRace(string name, int laps)
        {
            IRace raceFound = this.raceRepository.GetByName(name);

            if (raceFound != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RaceExists,
                    name));
            }

            raceFound = new Race(name, laps);

            this.raceRepository.Add(raceFound);

            return string.Format(OutputMessages.RaceCreated, raceFound.Name);
        }

        public string StartRace(string raceName)
        {
            IRace foundRace = this.raceRepository
                .GetByName(raceName);

            if (foundRace == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound,
                    raceName));
            }

            if (foundRace.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid,
                    raceName, 3));
            }

            var allRiders = foundRace.Riders;

            var sortedRiders = allRiders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(foundRace.Laps))
                .Take(3)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition,
                sortedRiders[0].Name, foundRace.Name));

            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition,
                sortedRiders[1].Name, foundRace.Name));

            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition,
                sortedRiders[2].Name, foundRace.Name));

            this.raceRepository.Remove(foundRace);

            return sb.ToString().TrimEnd();
        }
    }
}
