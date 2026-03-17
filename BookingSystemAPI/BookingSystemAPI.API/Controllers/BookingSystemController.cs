using BookingSystemAPI.API.DTOs;
using BookingSystemAPI.Core.CustomExceptions;
using BookingSystemAPI.Core.Interfaces;
using BookingSystemAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BookingSystemAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingSystemController : ControllerBase
    {
        private readonly ILogger<BookingSystemController> _logger;
        private readonly IBookingService _service;

        public BookingSystemController(ILogger<BookingSystemController> logger, 
                                        IBookingService service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Creates a booking request
        /// </summary>
        /// <response code="201">Booking request created successfully</response>
        /// <response code="400">Invalid booking request</response>
        /// <response code="500">Error</response>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookingDTO>> CreateBookingRequest(CreateBookingRequestModel createBooking)
        {
            _logger.LogInformation($"Received new create booking request with details: {JsonSerializer.Serialize(createBooking)}");

            try
            {
                var createdBooking = await _service.CreateBookingAsync(createBooking);

                return StatusCode(StatusCodes.Status201Created, BookingDTO.FromBookingModel(createdBooking));
            }
            catch (BookingValidationException validationEx)
            {
                _logger.LogError($"Create booking request validation failed: {validationEx.Message}");
                return BadRequest(validationEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating booking request: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the booking request.");
            }
        }

        /// <summary>
        /// Update a booking request
        /// </summary>
        /// <response code="200">Booking request updated successfully</response>
        /// <response code="400">Invalid booking request</response>
        /// <response code="404">Booking request not found</response>
        /// <response code="500">Error</response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookingDTO>> UpdateBookingRequest(UpdateBookingRequestModel updateBooking)
        {
            _logger.LogInformation($"Received new update booking request with details: {JsonSerializer.Serialize(updateBooking)}");

            try
            {
                var updatedBooking = await _service.UpdateBookingAsync(updateBooking);

                return StatusCode(StatusCodes.Status200OK, BookingDTO.FromBookingModel(updatedBooking));
            }
            catch (BookingValidationException validationEx)
            {
                _logger.LogError($"Update booking request validation failed: {validationEx.Message}");
                return BadRequest(validationEx.Message);
            }
            catch (BookingNotFoundException notFoundEx)
            {
                _logger.LogError($"Booking request not found for Id: {notFoundEx.Message}");
                return NotFound(notFoundEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating booking request: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the booking request.");
            }
        }

        /// <summary>
        /// (Soft) Delete a booking request
        /// </summary>
        /// <response code="200">Booking request deleted successfully</response>
        /// <response code="404">Booking request not found</response>
        /// <response code="500">Error</response>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookingDTO>> DeleteBookingRequest(DeleteBookingRequestModel deleteBooking)
        {
            _logger.LogInformation($"Received new delete booking request with details: {JsonSerializer.Serialize(deleteBooking)}");

            try
            {
                var deletedBooking = await _service.DeleteBookingAsync(deleteBooking);

                return StatusCode(StatusCodes.Status200OK, BookingDTO.FromBookingModel(deletedBooking));
            }
            catch (BookingNotFoundException notFoundEx)
            {
                _logger.LogError($"Booking request not found for Id: {notFoundEx.Message}");
                return NotFound(notFoundEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting booking request: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the booking request.");
            }
        }
    }
}
