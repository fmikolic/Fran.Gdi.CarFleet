using Fran.Gdi.CarFleet.Models;

namespace Fran.Gdi.CarFleet.Services;

public interface IDriversService
{
    public Task<List<Driver>> GetAllAsync();
}
