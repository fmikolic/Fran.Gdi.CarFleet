using Fran.Gdi.CarFleet.Models.Base;

namespace Fran.Gdi.CarFleet.Models;

public class Premise : ILocation
{
    public int? Id { get; set; }

    public required string Name { get; set; }

    public required string Address { get; set; }

    public required string PostalCode { get; set; }

    public required string City { get; set; }

    public required double Lon { get; set; }

    public required double Lat { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = null!;
}
