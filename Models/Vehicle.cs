using Fran.Gdi.CarFleet.Models.Base;

namespace Fran.Gdi.CarFleet.Models;

public class Vehicle
{
    public int Id { get; set; }

    public required string Model { get; set; }
    public required string RegistrationNumber { get; set; }
    public required int ProductionYear { get; set; }
    public required double MaxLoadCapacityKg { get; set; }

    public virtual ICollection<DriverVehicleAllocationEvent> AllocationEvents { get; set; } = null!;
}
