using EventsBookingBackend.Application.Common;
using EventsBookingBackend.Application.Models.Booking.Requests;
using EventsBookingBackend.Application.Models.Booking.Responses;
using EventsBookingBackend.Application.Services.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsBookingBackend.Api.Controllers;

public class BookingController(IBookService bookService) : AppBaseController
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateBookingResponse>> CreateBooking(
        [FromQuery] CreateBookingRequest request)
    {
        return Ok(await bookService.CreateBooking(request));
    }
}