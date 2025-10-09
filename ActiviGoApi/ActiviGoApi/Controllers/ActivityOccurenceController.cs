using Microsoft.AspNetCore.Mvc;
using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.Interfaces;
using AutoMapper;
using ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs;

namespace ActiviGoApi.WebApi.Controllers
{
    public class ActivityOccurenceController : ControllerBase
    {
        private readonly IActivityOccurenceService _occurrenceService;
        private readonly IMapper _mapper;
        public ActivityOccurenceController(IActivityOccurenceService occurrenceService, IMapper mapper)
        {
            _occurrenceService = occurrenceService;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all activity occurrences
        /// </summary>
        /// <returns></returns>
        // GET: api/activityoccurrences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityOccurence>>> GetAllOccurrences(CancellationToken ct)
        {
            var occurrences = await _occurrenceService.GetAllAsync(ct);
            return Ok(occurrences);
        }
        /// <summary>
        /// Get activity occurrence by id
        /// </summary>
        /// <returns></returns>
        // GET: api/activityoccurrences/
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityOccurenceResponseDTO>> GetOccurrence(int id, CancellationToken ct)
        {
            try
            {

                var activityOccurence = _mapper.Map<ActivityOccurenceResponseDTO>(id, ct);
                return Ok(activityOccurence);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
        /// <summary>
        /// Create a new activity occurrence
        /// </summary>
        /// <returns></returns>
        // POST: api/activityoccurrences
        [HttpPost]
        public async Task<ActionResult<ActivityOccurenceResponseDTO>> CreateOccurrence(
            [FromBody] CreateActivityOccurrenceDTO dto,
            CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dto.StartTime >= dto.EndTime)
            {
                return BadRequest("StartTime must be before EndTime");
            }

            var occurrence = _mapper.Map<ActivityOccurence>(dto);
            var created = await _occurrenceService.CreateOccurrenceAsync(occurrence, ct);
            var response = _mapper.Map<ActivityOccurenceResponseDTO>(created);

            return CreatedAtAction(
                nameof(GetOccurrence),
                new { id = response.Id },
                response
            );
        }
        /// <summary>
        /// Update an existing activity occurrence
        /// </summary>
        /// <returns></returns>
        // PUT: api/activityoccurrences/
        [HttpPut("{id}")]
        public async Task<ActionResult<ActivityOccurenceResponseDTO>> UpdateOccurrence(
         int id,
         [FromBody] UpdateActivityOccurrenceDTO dto,
         CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dto.StartTime >= dto.EndTime)
            {
                return BadRequest("StartTime must be before EndTime");
            }

            var occurrence = _mapper.Map<ActivityOccurence>(dto);
            var updated = await _occurrenceService.UpdateOccurrenceAsync(id, occurrence, ct);

            if (updated == null)
            {
                return NotFound($"Activity occurrence with id {id} not found");
            }

            var response = _mapper.Map<ActivityOccurenceResponseDTO>(updated);
            return Ok(response);
        }
        /// <summary>
        /// Delete an activity occurrence
        /// </summary>
        /// <returns></returns>
        // DELETE: api/activityoccurrences/
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOccurrence(int id, CancellationToken ct)
        {
            var deleted = await _occurrenceService.DeleteOccurrenceAsync(id, ct);

            if (deleted == null)
            {
                return NotFound($"Activity occurrence with id" +
                    $" {id} not found");
            }

            return NoContent();
        }
    }
    
}
