using System.Linq;
using System.Collections.Generic;

using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.guns.AsReadOnly();

        public void Add(IGun model)
        {
            bool doesItExist = this.guns.Any(g => g.Name == model.Name);

            if (!doesItExist)
            {
                this.guns.Add(model);
            }
        }

        public IGun Find(string name)
        {
            IGun gun = this.guns.First(g => g.Name == name);

            return gun;
        }

        public bool Remove(IGun model)
        {
            return this.guns.Remove(model);
        }
    }
}
