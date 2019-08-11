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

        private readonly Queue<IGun> guns;
        private readonly List<IPlayer> civilPlayers;
        private readonly IRepository<IGun> gunRepository;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.neighbourhood = new GangNeighbourhood();

            this.guns = new Queue<IGun>();
            this.civilPlayers = new List<IPlayer>();
            this.gunRepository = new GunRepository();
        }

        public string AddPlayer(string name)
        {
            IPlayer civilPlayer = new CivilPlayer(name);

            this.civilPlayers.Add(civilPlayer);

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

            this.guns.Enqueue(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            IGun gun = null;

            if (name == "Vercetti")
            {
                gun = this.guns.Dequeue();

                this.mainPlayer.GunRepository.Add(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            bool doesPlayerNameExist = this.civilPlayers.Any(p => p.Name == name);

            if (!doesPlayerNameExist)
            {
                return "Civil player with that name doesn't exists!";
            }

            gun = this.guns.Dequeue();

            IPlayer civilPlayer = this.civilPlayers.First(p => p.Name == name);

            civilPlayer.GunRepository.Add(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {civilPlayer.Name}";
        }

        public string Fight()
        {
            this.neighbourhood.Action(mainPlayer, this.civilPlayers);

            if (mainPlayer.IsAlive && this.civilPlayers.Any(p => p.IsAlive))
            {
                return "Everything is okay!";
            }

            StringBuilder sb = new StringBuilder();

            if (this.civilPlayers.Any(p => !p.IsAlive))
            {
                int deadCivilPlayersCount = this.civilPlayers.Count(p => !p.IsAlive);

                sb.AppendLine("A fight happened:")
                    .AppendLine($"Tommy live points: {mainPlayer.LifePoints}!")
                    .AppendLine($"Tommy has killed: {deadCivilPlayersCount} players!")
                    .AppendLine($"Left Civil Players: {this.civilPlayers.Count}!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
