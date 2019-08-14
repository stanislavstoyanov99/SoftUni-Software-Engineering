using System.Linq;
using System.Text;
using System.Collections.Generic;

using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private readonly IPlayer mainPlayer;
        private readonly INeighbourhood neighbourhood;

        private readonly List<IPlayer> players;
        private readonly IRepository<IGun> gunRepository;

        private const string MainPlayerNameKey = "Vercetti";
        private const string FullNameMainPlayer = "Tommy Vercetti";
        private const int InitialMainPlayerHealthPoints = 100;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.neighbourhood = new GangNeighbourhood();

            this.players = new List<IPlayer>()
            {
                this.mainPlayer
            };

            this.gunRepository = new GunRepository();
        }

        public string AddPlayer(string name)
        {
            IPlayer civilPlayer = new CivilPlayer(name);

            this.players.Add(civilPlayer);

            return $"Successfully added civil player: {civilPlayer.Name}!";
        }

        public string AddGun(string type, string name)
        {
            IGun gun;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }
            else
            {
                return $"Invalid gun type!";
            }

            this.gunRepository.Add(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.gunRepository.Models.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            IGun gun = this.gunRepository.Models
                    .First(g => g.CanFire == true);

            if (name == MainPlayerNameKey)
            {
                IPlayer playerVercetti = this.players
                    .FirstOrDefault(p => p.Name == FullNameMainPlayer && p.GetType().Name == nameof(MainPlayer));

                this.gunRepository.Remove(gun);

                playerVercetti.GunRepository.Add(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            bool doesPlayerNameExist = this.players.Any(p => p.Name == name);

            if (!doesPlayerNameExist)
            {
                return "Civil player with that name doesn't exists!";
            }

            IPlayer civilPlayer = this.players.First(p => p.Name == name);

            this.gunRepository.Remove(gun);

            civilPlayer.GunRepository.Add(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {civilPlayer.Name}";
        }

        public string Fight()
        {
            IPlayer mainPlayer = this.players
                .First(p => p.GetType().Name == nameof(MainPlayer));

            List<IPlayer> civilPlayers = this.players
                .Where(p => p.GetType().Name == nameof(CivilPlayer))
                .ToList();

            this.neighbourhood.Action(mainPlayer, civilPlayers);

            StringBuilder sb = new StringBuilder();

            if (mainPlayer.LifePoints == InitialMainPlayerHealthPoints &&
                civilPlayers.Any(p => p.IsAlive))
            {
                return "Everything is okay!";
            }
            else
            {

                int deadCivilPlayersCount = civilPlayers.Count(p => !p.IsAlive);
                int leftCivilPlayersCount = civilPlayers.Count(p => p.IsAlive);

                sb.AppendLine("A fight happened:")
                    .AppendLine($"Tommy live points: {mainPlayer.LifePoints}!")
                    .AppendLine($"Tommy has killed: {deadCivilPlayersCount} players!")
                    .AppendLine($"Left Civil Players: {leftCivilPlayersCount}!");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
