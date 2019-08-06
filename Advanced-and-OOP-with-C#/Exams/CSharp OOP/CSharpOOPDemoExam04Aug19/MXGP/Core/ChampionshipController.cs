namespace MXGP.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using MXGP.Core.Contracts;
    using MXGP.Factories;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Races;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories;
    using MXGP.Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private MotorcycleFactory motorcycleFactory;

        private MotorcycleRepository motorcycleRepository;

        private RaceRepository raceRepository;

        private RiderRepository riderRepository;

        public ChampionshipController(
            MotorcycleFactory motorcycleFactory,
            MotorcycleRepository motorcycleRepository,
            RaceRepository raceRepository,
            RiderRepository riderRepository)
        {
            this.motorcycleFactory = motorcycleFactory;

            this.motorcycleRepository = motorcycleRepository;
            this.raceRepository = raceRepository;
            this.riderRepository = riderRepository;
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

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle foundMotorcycle = this.motorcycleRepository
                .GetByName(model);

            if (foundMotorcycle != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists,
                    model));
            }

            IMotorcycle motorcycle = this.motorcycleFactory
                .CreateMotorcycle(type, model, horsePower);


            this.motorcycleRepository.Add(motorcycle);

            return string.Format(OutputMessages.MotorcycleCreated,
                motorcycle.GetType().Name, motorcycle.Model);
        }

        public string CreateRace(string name, int laps)
        {
            IRace raceFound = this.raceRepository.GetByName(name);

            if (raceFound != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RaceExists,
                    name));
            }

            IRace race = new Race(name, laps);

            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, race.Name);
        }

        public string CreateRider(string riderName)
        {
            IRider riderFound = this.riderRepository.GetByName(riderName);

            if (riderFound != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists,
                    riderName));
            }

            IRider rider = new Rider(riderName);

            this.riderRepository.Add(rider);

            return string.Format(OutputMessages.RiderCreated, rider.Name);
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

            var allRiders = this.riderRepository.GetAll();

            var sortedRiders = allRiders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(foundRace.Laps))
                .ToList();

            this.raceRepository.Remove(foundRace);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rider {sortedRiders.First().Name} wins {foundRace.Name} race.");
            sb.AppendLine($"Rider {sortedRiders[1].Name} is second in {foundRace.Name} race.");
            sb.AppendLine($"Rider {sortedRiders.Last().Name} is third in {foundRace.Name} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
