using Fran.Gdi.CarFleet.Models;
using Fran.Gdi.CarFleet.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fran.Gdi.CarFleet.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<List<Driver>>> GetAsync()
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
    }
}
