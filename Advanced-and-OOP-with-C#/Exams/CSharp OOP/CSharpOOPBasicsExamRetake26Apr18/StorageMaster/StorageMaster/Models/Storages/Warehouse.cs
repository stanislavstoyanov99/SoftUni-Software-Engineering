using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class Warehouse : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Semi(),
            new Semi(),
            new Semi()
        };

        private const int InitialCapacity = 10;
        private const int InitialGarageSlots = 10;

        public Warehouse(string name) 
            : base(name, InitialCapacity, InitialGarageSlots, DefaultVehicles)
        {

        }
    }
}
