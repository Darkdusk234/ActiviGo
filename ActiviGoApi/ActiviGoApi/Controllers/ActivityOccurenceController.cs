using Microsoft.AspNetCore.Mvc;
using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.Interfaces;
using AutoMapper;
using ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs;
using FluentValidation;
using ActiviGoApi.Services.Services;

namespace ActiviGoApi.WebApi.Controllers
{
    public class ActivityOccurenceController : ControllerBase
    {
        private readonly IActivityOccurenceService _occurrenceService;
        private readonly IValidator<CreateActivityOccurrenceDTO> _createVali;
        private readonly IValidator<UpdateActivityOccurrenceDTO> _updateVali;
        public ActivityOccurenceController(IActivityOccurenceService occurrenceService, IValidator<CreateActivityOccurrenceDTO> createVali, 
            IValidator<UpdateActivityOccurrenceDTO> updateVali)
        {
            _occurrenceService = occurrenceService;
            _createVali = createVali;
            _updateVali = updateVali;
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
                var location = await _occurrenceService.GetByIdAsync(id, ct);
                return Ok(location);
            }
            catch (Exception ex)
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
        public async Task<ActionResult<ActivityOccurenceResponseDTO>> CreateOccurrence([FromBody] CreateActivityOccurrenceDTO dto,CancellationToken ct)
        {
            var validResult = await _createVali.ValidateAsync(dto, ct);
            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }
            try
            {
                var newOccurrence = await _occurrenceService.CreateAsync(dto, ct);
                return CreatedAtAction(nameof(GetOccurrence), new { id = newOccurrence.Id }, newOccurrence);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        /// <summary>
        /// Update an existing activity occurrence
        /// </summary>
        /// <returns></returns>
        // PUT: api/activityoccurrences/
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ActivityOccurenceResponseDTO>> UpdateOccurrence(int id,[FromBody] UpdateActivityOccurrenceDTO dto,CancellationToken ct)
        {
            var validResult = await _updateVali.ValidateAsync(dto, ct);
            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            try
            {
                var updatedOccurrence = await _occurrenceService.UpdateAsync(id, dto, ct);
                return Ok(updatedOccurrence);
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Delete an activity occurrence
        /// </summary>
        /// <returns></returns>
        // DELETE: api/activityoccurrences/
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOccurrence(int id, CancellationToken ct)
        {
            try
            {
                await _occurrenceService.DeleteAsync(id, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
    
}
