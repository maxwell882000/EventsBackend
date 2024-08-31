using EventsBookingBackend.Application.Common;
using EventsBookingBackend.Application.Models.Booking.Requests;
using EventsBookingBackend.Application.Models.Booking.Responses;
using EventsBookingBackend.Application.Services.Book;
using Microsoft.AspNetCore.Mvc;

namespace EventsBookingBackend.Api.Controllers;

public class BookingController(IBookService bookService) : AppBaseController
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("get-booking-type")]
    public async Task<ActionResult<GetBookingTypeByCategoryResponse>> GetBookingType(
        [FromQuery] GetBookingTypeByCategoryRequest request)
    {
        return Ok(await bookService.GetBookingType(request));
    }
}