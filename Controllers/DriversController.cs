using Fran.Gdi.CarFleet.Exceptions;
using Fran.Gdi.CarFleet.Models;
using Fran.Gdi.CarFleet.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Fran.Gdi.CarFleet.Controllers
{
    [ApiController]
    [Route("drivers")]
    public class DriversController : ControllerBase
    {
        private readonly IDriversService _drivers;

        public DriversController(IDriversService drivers)
        {
            this._drivers = drivers;
        }

        [HttpGet]
        public async Task<ActionResult<List<Driver>>> GetAllAsync()
        {
            var response = await this._drivers.GetAllAsync();

            if (response.Any())
            {
                return this.Ok(response);
            }
            else
            {
                return this.NoContent();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Driver>> CreateAsync(string name, string surname)
        {
            var created = await this._drivers.CreateAsync(name, surname);

            return Ok(created);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetByIdAsync(int id)
        {
            try
            {
                var response = await this._drivers.GetByIdAsync(id);

                return this.Ok(response);
            }
            catch (EntityNotFoundException ex)
            {
                return this.NotFound(ex.Query);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Driver>> DeleteByIdAsync(int id)
        {
            try
            {
                await this._drivers.DeleteByIdAsync(id);

                return this.Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return this.NotFound(ex.Query);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Driver>> UpdateAsync(int id, string? name, string? surname)
        {
            try
            {
                var updated = await this._drivers.UpdateAsync(id, name: name, surname: surname);
                return Ok(updated);
            }
            catch (EntityNotFoundException ex)
            {
                return this.NotFound(ex.Query);
            }

        }
    }
}
