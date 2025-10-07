using ActiviGoApi.Services.DTOs.SubLocationDTOs;
using ActiviGoApi.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActiviGoApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubLocationController : ControllerBase
    {
        private readonly ISubLocationService _subLocationService;
        private readonly IValidator<CreateSubLocationRequest> _createValidator;
        private readonly IValidator<UpdateSubLocationRequest> _updateValidator;

        public SubLocationController(ISubLocationService subLocationService,
            IValidator<CreateSubLocationRequest> createValidator,
            IValidator<UpdateSubLocationRequest> updateValidator)
        {
            _subLocationService = subLocationService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubLocation([FromBody] CreateSubLocationRequest request, CancellationToken ct = default)
        {
            var validationResult = await _createValidator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var createdSubLocation = await _subLocationService.CreateSubLocationAsync(request, ct);
            
            return Ok(createdSubLocation);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSubLocationResponse>>> GetAllSubLocations(CancellationToken ct = default)
        {
            var subLocations = await _subLocationService.GetAllSubLocationsAsync(ct);
            return Ok(subLocations);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSubLocationResponse>> GetSubLocationById(int id, CancellationToken ct = default)
        {
            var subLocation = await _subLocationService.GetSubLocationByIdAsync(id, ct);
            if (subLocation == null)
            {
                return NotFound();
            }
            return Ok(subLocation);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubLocation(int id, [FromBody] UpdateSubLocationRequest request, CancellationToken ct = default)
        {
            var validationResult = await _updateValidator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var updated = await _subLocationService.UpdateSubLocationAsync(id, request, ct);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubLocation(int id, CancellationToken ct = default)
        {
            var deleted = await _subLocationService.DeleteSubLocationAsync(id, ct);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok("Sublocation deleted");
        }

    }
}
