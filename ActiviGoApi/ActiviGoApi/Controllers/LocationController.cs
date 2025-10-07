using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ActiviGoApi.Core.Models;
using ActiviGoApi.Core.Interfaces;
using ActiviGoApi.Services.Interfaces;

namespace ActiviGoApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService) 
        { 
            _locationService = locationService;
        }

        // GET: api/locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocations(CancellationToken ct)
        {
            var locations = await _locationService.GetAllAsync(ct);
            return Ok(locations);
        }

        // GET: api/locations
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id, CancellationToken ct)
        {
            var location = await _locationService.GetByIdAsync(id, ct);

            if (location == null)
            {
                return NotFound($"Location with id {id} not found");
            }

            return Ok(location);
        }

        // POST: api/locations
        [HttpPost]
        public async Task<ActionResult<Location>> CreateLocation([FromBody] Location location, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdLocation = await _locationService.AddAsync(location, ct);

            return CreatedAtAction(
                nameof(GetLocation),
                new { id = createdLocation.Id },
                createdLocation
            );
        }

        // PUT: api/locations
        [HttpPut("{id}")]
        public async Task<ActionResult<Location>> UpdateLocation(int id, [FromBody] Location location, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedLocation = await _locationService.UpdateAsync(id, location, ct);

            if (updatedLocation == null)
            {
                return NotFound($"Location with id {id} not found");
            }

            return Ok(updatedLocation);
        }

        // DELETE: api/locations
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLocation(int id, CancellationToken ct)
        {
            var result = await _locationService.DeleteAsync(id, ct);

            if (!result)
            {
                return NotFound($"Location with id {id} not found");
            }

            return NoContent();
        }

    }
}
