using ActiviGoApi.Services.DTOs;
using ActiviGoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ActiviGoApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingReadDTO>>> GetAll(CancellationToken ct)
        {
            try
            {
                var bookings = await _service.GetAllAsync(ct);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ✅ POST: api/booking
        [HttpPost]
        public async Task<ActionResult<BookingReadDTO>> Create([FromBody] BookingCreateDTO createDto, CancellationToken ct)
        {
            try
            {
                var created = await _service.AddAsync(createDto, ct);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookingUpdateDTO updateDto, CancellationToken ct)
        {
            try
            {
                var updated = await _service.UpdateAsync(id, updateDto, ct);
                if (!updated)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ✅ DELETE: api/booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            try
            {
                var deleted = await _service.DeleteAsync(id, ct);
                if (!deleted)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
