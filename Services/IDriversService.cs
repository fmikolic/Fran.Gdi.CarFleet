using Fran.Gdi.CarFleet.Models;

namespace Fran.Gdi.CarFleet.Services;

public interface IDriversService
{
    /// <summary>
    /// Returns all drivers in the system.
    /// </summary>
    /// <returns>List of all drivers in the system.</returns>
    public Task<List<Driver>> GetAllAsync();

    /// <summary>
    /// Creates new <see cref="Driver"/> in the system.
    /// </summary>
    /// <param name="name">Name of the new driver.</param>
    /// <param name="surname">Surname of the new driver.</param>
    /// <returns>Newly created <see cref="Driver"/>.</returns>
    public Task<Driver> CreateAsync(string name, string surname);

    public Task<Driver> UpdateAsync(int id, string? name = null, string? surname = null);

    public Task DeleteByIdAsync(int id);

    public Task<Driver> GetByIdAsync(int id);


}
