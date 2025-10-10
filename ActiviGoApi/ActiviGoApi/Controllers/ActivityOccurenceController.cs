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
        private readonly IValidator<ActivityOccurenceSearchFilterDTO> _searchVali;
        public ActivityOccurenceController(IActivityOccurenceService occurrenceService, IValidator<CreateActivityOccurrenceDTO> createVali, 
            IValidator<UpdateActivityOccurrenceDTO> updateVali, IValidator<ActivityOccurenceSearchFilterDTO> searchVali)
        {
            _occurrenceService = occurrenceService;
            _createVali = createVali;
            _updateVali = updateVali;
            _searchVali = searchVali;
        }

        /// <summary>
        /// Get all activity occurrences
        /// </summary>
        /// <returns></returns>
        // GET: api/activityoccurrences
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ActivityOccurenceResponseDTO>>> GetAllOccurrences(CancellationToken ct)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ActivityOccurenceResponseDTO>> GetOccurrence(int id, CancellationToken ct)
        {
            try
            {
                var occurrence = await _occurrenceService.GetByIdAsync(id, ct);

                if (occurrence == null)
                {
                    return NotFound($"Activity occurrence with id {id} not found");
                }

                return Ok(occurrence);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving activity occurrence with id {id}");
            }

        }

        /// <summary>
        /// Create a new activity occurrence
        /// </summary>
        /// <returns></returns>
        // POST: api/activityoccurrences
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ActivityOccurenceResponseDTO>> CreateOccurrence([FromBody] CreateActivityOccurrenceDTO dto,CancellationToken ct)
        {
            var validResult = await _createVali.ValidateAsync(dto, ct);
            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }
            try
            {
                var newOccurrence = await _occurrenceService.AddAsync(dto, ct);
                return CreatedAtAction(nameof(GetOccurrence), new { id = newOccurrence.Id }, newOccurrence);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);    // not find the activity or sublocation id
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the activity occurrence");
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
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
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
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ActivityOccurenceResponseDTO>>> SearchOccurrences([FromBody] ActivityOccurenceSearchFilterDTO dto, CancellationToken ct)
        {

            var validResult = await _searchVali.ValidateAsync(dto, ct);
            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            try
            {
                var occurrences = await _occurrenceService.GetFilteredActivityOccurences(dto, ct);
                return Ok(occurrences);
            }
            catch (Exception ex) // Very temporary error handling
            {
                return StatusCode(500, "An error occurred while searching for activity occurrences");
            }
        }
    }
    
}
