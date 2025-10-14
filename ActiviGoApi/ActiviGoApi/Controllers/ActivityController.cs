using ActiviGoApi.Infrastructur.Repositories;
using ActiviGoApi.Services.DTOs.ActivityDTOs;
using ActiviGoApi.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActiviGoApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IValidator<CreateActivityRequest> _createValidator;
        private readonly IValidator<UpdateActivityRequest> _updateValidator;

        public ActivityController(IActivityService activityService, IValidator<CreateActivityRequest> createValidator, IValidator<UpdateActivityRequest> updateValidator)
        {
            _activityService = activityService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityRequest dto, CancellationToken ct = default)
        {
            var validationResult = await _createValidator.ValidateAsync(dto, ct);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var result = await _activityService.CreateActivityAsync(dto, ct);

                return Ok("Activity created successfully");
            }
            catch(KeyNotFoundException ex)
            { 
                return NotFound(ex.Message);
            }
            
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetActivityResponse>>> GetAllActivities(CancellationToken ct = default)
        {
            try 
            { 
                var allActivities = await _activityService.GetAllActivitiesAsync(ct);
                return Ok(allActivities);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetActivityResponse>> GetActivityById(int id, CancellationToken ct = default)
        {
            try
            {
                var activity = await _activityService.GetActivityByIdAsync(id, ct);
                return Ok(activity);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("category/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<GetActivityResponse>>> GetActivitiesByCategoryId(int categoryId, CancellationToken ct = default)
        {
            try
            {
                var activities = await _activityService.GetActivitiesByCategoryIdAsync(categoryId, ct);
                return Ok(activities);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromBody] UpdateActivityRequest dto, CancellationToken ct = default)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto, ct);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var result = await _activityService.UpdateActivityAsync(id, dto, ct);
                return Ok("Activity updated successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id, CancellationToken ct = default)
        {
            try
            {
                var result = await _activityService.DeleteActivityAsync(id, ct);
                return Ok("Activity deleted successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
