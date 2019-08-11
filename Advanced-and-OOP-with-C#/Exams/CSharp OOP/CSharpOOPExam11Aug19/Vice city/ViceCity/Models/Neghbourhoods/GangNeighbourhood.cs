using System.Collections.Generic;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        // TODO
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var gun in mainPlayer.GunRepository.Models)
            {
                foreach (var player in civilPlayers)
                {
                    while (true)
                    {
                        player.TakeLifePoints(gun.Fire());

                        if (!player.IsAlive)
                        {
                            break;
                        }
                    }

                    if (!player.IsAlive)
                    {
                        break;
                    }

                    if (gun.TotalBullets == 0)
                    {
                        break;
                    }
                }

                if (gun.TotalBullets == 0)
                {
                    break;
                }
            }

            foreach (var civilPlayer in civilPlayers)
            {
                foreach (var gun in civilPlayer.GunRepository.Models)
                {
                    while (true)
                    {
                        mainPlayer.TakeLifePoints(gun.Fire());

                        if (!mainPlayer.IsAlive)
                        {
                            break;
                        }
                    }

                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }

                    if (gun.TotalBullets == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
