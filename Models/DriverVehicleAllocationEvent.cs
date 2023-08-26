using Fran.Gdi.CarFleet.Models.Base;

namespace Fran.Gdi.CarFleet.Models
{
    public class DriverVehicleAllocationEvent : IVehicleEvent, IDriverEvent, ILocation
    {
        public int Id { get; set; }

        public required DriverVehicleAllocationEventType AllocationEventType { get; set; }

        public required double Lon { get; set; }

        public required double Lat { get; set; }

        public int VehicleId { get; set; }

        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; } = null!;

        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
