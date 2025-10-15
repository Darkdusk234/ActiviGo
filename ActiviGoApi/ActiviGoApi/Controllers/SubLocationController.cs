using ActiviGoApi.Services.DTOs.SubLocationDTOs;
using ActiviGoApi.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateSubLocation([FromBody] CreateSubLocationRequest request, CancellationToken ct = default)
        {
            var validationResult = await _createValidator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var createdSubLocation = await _subLocationService.CreateSubLocationAsync(request, ct);
            
                return Ok(createdSubLocation);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSubLocationResponse>>> GetAllSubLocations(CancellationToken ct = default)
        {
            try
            {
                var subLocations = await _subLocationService.GetAllSubLocationsAsync(ct);
                return Ok(subLocations);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetSubLocationResponse>> GetSubLocationById(int id, CancellationToken ct = default)
        {
            try
            {
                var subLocation = await _subLocationService.GetSubLocationByIdAsync(id, ct);

                if (subLocation == null)
                {
                    return NotFound();
                }
                return Ok(subLocation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubLocation(int id, [FromBody] UpdateSubLocationRequest request, CancellationToken ct = default)
        {
            var validationResult = await _updateValidator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {

                var updated = await _subLocationService.UpdateSubLocationAsync(id, request, ct);
                if (!updated)
                {
                    return NotFound();
                }
                    return Ok("Sublocation updated");
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }  
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubLocation(int id, CancellationToken ct = default)
        {
            try
            {
                var deleted = await _subLocationService.DeleteSubLocationAsync(id, ct);
                if (!deleted)
                {
                    return NotFound();
                }
                return Ok("Sublocation deleted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }

    }
}
