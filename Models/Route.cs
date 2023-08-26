namespace Fran.Gdi.CarFleet.Models;

public class Route
{
    public int? Id { get; set; }

    public required int StartingPremiseId { get; set; }

    public required int TargetPremiseId { get; set; }

    public required int VehicleId { get; set; }

    public required RouteStatus RouteStatus { get; set; }

    public virtual Premise StartingPremise { get; set; } = null!;

    public virtual Premise TargetPremise { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
