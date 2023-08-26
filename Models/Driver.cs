using Fran.Gdi.CarFleet.Models.Base;

namespace Fran.Gdi.CarFleet.Models
{
    public class Driver
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Surname { get; set; }

        public virtual ICollection<IVehicleEvent> AllocationEvents { get; set; } = null!;
    }
}
