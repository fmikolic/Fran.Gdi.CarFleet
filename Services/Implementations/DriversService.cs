using Fran.Gdi.CarFleet.Data;
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

    public Task<List<Driver>> GetAllAsync()
    {
        var result = this._ctx.Drivers
            .ToListAsync();

        return result;
    }
}
