using ActiviGoApi.Services.DTOs.BookingDTOs;
using ActiviGoApi.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActiviGoApi.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;
        private readonly IValidator<BookingCreateDTO> _createValidator;
        private readonly IValidator<BookingUpdateDTO> _updateValidator;


        public BookingController(IBookingService service, IValidator<BookingCreateDTO> createValidator,
            IValidator<BookingUpdateDTO> updateValidator)
        {
            _service = service;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingReadDTO>>> GetAll(CancellationToken ct)
        {
            var bookings = await _service.GetAllAsync(ct);
            return Ok(bookings);   
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingReadDTO>> GetById(int id, CancellationToken ct)
        {
            try
            {
                var booking = await _service.GetByIdAsync(id, ct);
                if (booking == null)
                    return NotFound();

                return Ok(booking);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookingReadDTO>> Create([FromBody] BookingCreateDTO createDto, CancellationToken ct)
        {
            var validationResult = await _createValidator.ValidateAsync(createDto, ct);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return BadRequest($"Validation failed: {errors}");
            }
            try
            {
                var created = await _service.AddAsync(createDto, ct);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookingUpdateDTO updateDto, CancellationToken ct)
        {   
            var validationResult = await _updateValidator.ValidateAsync(updateDto, ct);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return BadRequest($"Validation failed: {errors}");
            }

            try
            {
                var updated = await _service.UpdateAsync(id, updateDto, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("cancel/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelBooking(int id, CancellationToken ct)
        {
            try
            {
                await _service.CancelBookingAsync(id, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            try
            {
                await _service.DeleteAsync(id, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
