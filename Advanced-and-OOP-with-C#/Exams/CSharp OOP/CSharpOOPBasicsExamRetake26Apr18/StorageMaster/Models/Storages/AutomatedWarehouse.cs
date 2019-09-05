using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Truck()
        };

        private const int InitialCapacity = 1;
        private const int InitialGarageSlots = 2;

        public AutomatedWarehouse(string name)
            : base(name, InitialCapacity, InitialGarageSlots, DefaultVehicles)
        {

        }
    }
}
