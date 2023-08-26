using Fran.Gdi.CarFleet.Models.Base;

namespace Fran.Gdi.CarFleet.Models
{
    public class VehicleLocationEvent : IVehicleEvent, ILocation
    {
        public double Lon { get; set; }

        public double Lat { get; set; }

        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
