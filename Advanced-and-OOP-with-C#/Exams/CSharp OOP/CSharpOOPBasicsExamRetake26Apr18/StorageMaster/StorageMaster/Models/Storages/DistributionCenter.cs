using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class DistributionCenter : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Van(),
            new Van(),
            new Van()
        };

        private const int InitialCapacity = 2;
        private const int InitialGarageSlots = 5;

        public DistributionCenter(string name)
            : base(name, InitialCapacity, InitialGarageSlots, DefaultVehicles)
        {

        }
    }
}
