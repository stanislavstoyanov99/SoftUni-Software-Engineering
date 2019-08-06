namespace MXGP.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using MXGP.Repositories.Contracts;
    using MXGP.Models.Riders.Contracts;

    public class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public void Add(IRider model)
        {
            this.riders.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.riders.AsReadOnly();
        }

        public IRider GetByName(string name)
        {
            IRider rider = this.riders
                .FirstOrDefault(t => t.Name == name);

            return rider;
        }

        public bool Remove(IRider model)
        {
            return this.riders.Remove(model);
        }
    }
}
