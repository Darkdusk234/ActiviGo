using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ActiviGoApi.Core.Models;
using ActiviGoApi.Core.Interfaces;
using ActiviGoApi.Services.Interfaces;
using ActiviGoApi.Services.DTOs.CategpryDtos;
using FluentValidation;
using ActiviGoApi.Services.DTOs.LocationDTOs;
using ActiviGoApi.Services.Services;
using ActiviGoApi.Services.DTOs;

namespace ActiviGoApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IValidator<CreateLocationDTO> _createVali;
        private readonly IValidator<UpdateLocationDTO> _updateVali;

        public LocationController(ILocationService locationService, IValidator<CreateLocationDTO> createVali, IValidator<UpdateLocationDTO> updateVali) 
        { 
            _locationService = locationService;
            _createVali = createVali;
            _updateVali = updateVali;
        }

        // GET: api/locations
        /// <summary>
        /// Get all locations
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LocationRequestDTO>>> GetAllLocations(CancellationToken ct)
        {
            var locations = await _locationService.GetAllAsync(ct);
            return Ok(locations);
        }

        // GET: api/locations
        /// <summary>
        /// Get location by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocationRequestDTO>> GetById(int id, CancellationToken ct)
        {
            try
            {
                var location = await _locationService.GetByIdAsync(id, ct);
                if (location == null)
                {
                    return NotFound($"Location with id {id} not found");
                }
                return Ok(location);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        // POST: api/locations
        /// <summary>
        /// Create a new location
        /// </summary>
        /// <param name="createDTO"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocationRequestDTO>> CreateLocation([FromBody] CreateLocationDTO createDTO, CancellationToken ct)
        {
            var validResult = await _createVali.ValidateAsync(createDTO, ct);
            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            try
            {
                var newLocal = await _locationService.AddAsync(createDTO, ct);
                return(Ok(newLocal));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/locations
        /// <summary>
        /// Update a location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocationRequestDTO>> UpdateLocation(int id, UpdateLocationDTO updateDTO, CancellationToken ct)
        {
            if (id != updateDTO.Id)
            {
                return BadRequest("Id in URL does not match Id in request body");
            }
            var validResult = await _updateVali.ValidateAsync(updateDTO, ct);
            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            try
            {
                var updatedLocal = await _locationService.UpdateAsync(id, updateDTO, ct);
                return Ok(updatedLocal);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/locations
        /// <summary>
        /// Delete a location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteLocation(int id, CancellationToken ct)
        {
            try
            {
                await _locationService.DeleteAsync(id, ct);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
