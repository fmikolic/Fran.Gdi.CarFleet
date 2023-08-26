using Fran.Gdi.CarFleet.Data;
using Fran.Gdi.CarFleet.Exceptions;
using Fran.Gdi.CarFleet.Models;

using Microsoft.EntityFrameworkCore;

namespace Fran.Gdi.CarFleet.Services.Implementations;

public class DriversService : IDriversService
{
    private readonly ApplicationDbContext _ctx;

    public DriversService(ApplicationDbContext ctx)
    {
        this._ctx = ctx;
    }

    public async Task<Driver> CreateAsync(string name, string surname)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty!", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(surname))
        {
            throw new ArgumentException("Surname cannot be empty!", nameof(surname));
        }

        var newDriver = new Driver
        {
            Name = name,
            Surname = surname,
        };

        await this._ctx.Drivers.AddAsync(newDriver);

        await this._ctx.SaveChangesAsync();

        return newDriver;
    }

    public async Task<Driver> UpdateAsync(int id, string? name = null, string? surname = null)
    {
        var existingDriver = await this._ctx.Drivers
            .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new EntityNotFoundException(new { id });

        if (!string.IsNullOrWhiteSpace(name))
        {
            existingDriver.Name = name;
        }

        if (!string.IsNullOrWhiteSpace(surname))
        {
            existingDriver.Surname = surname;
        }

        await this._ctx.SaveChangesAsync();

        return existingDriver;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var existingDriver = await this._ctx.Drivers
            .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new EntityNotFoundException(new { id });

        this._ctx.Drivers.Remove(existingDriver);

        await this._ctx.SaveChangesAsync();
    }

    public Task<List<Driver>> GetAllAsync()
    {
        var result = this._ctx.Drivers
            .ToListAsync();

        return result;
    }

    public async Task<Driver> GetByIdAsync(int id)
    {
        var existingDriver = await this._ctx.Drivers
            .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new EntityNotFoundException(new { id });

        return existingDriver;
    }
}
