using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Dto.BookingDtos;
using resturangApi.Models;
using resturangApi.Repositories.Interface;
using resturangApi.Services;
using resturangApi.Services.Iservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturangApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IGenericRepository repo, IGenericItemService service,
        IBookingService bookingService) : ControllerBase
    {
        private readonly IGenericRepository _repo = repo;
        private readonly IGenericItemService _service = service;
        private readonly IBookingService _bookingService = bookingService;

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _repo.GetAll<Booking>();
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _repo.GetItemByID<Booking>(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBooking(int id, PatchBookingDto booking)
        {
           var result = await _service.UpdateItem<Booking, PatchBookingDto>(id, booking);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(CreateBookingDto booking)
        {

            // look to add some logic that returns a list of available tables if the selected one is not available
            //look to add logic that checks if the customer exists
            
            var result = await _bookingService.CreateBookingAsync(booking);
            if (result == null)
            {
                return BadRequest("Table is not available for the selected time and date.");
            }

            return CreatedAtAction("GetBooking", new { id = result.BookingId }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _service.DeleteItem<Booking>(id);
            if (booking == false)
            {
                return NotFound();
            }

            return Ok("Booking Deleted");
        }

    }
}
