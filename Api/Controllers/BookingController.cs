using EventsBookingBackend.Application.Common;
using EventsBookingBackend.Application.Models.Booking.Requests;
using EventsBookingBackend.Application.Models.Booking.Responses;
using EventsBookingBackend.Application.Services.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsBookingBackend.Api.Controllers;

[Authorize]
public class BookingController(IBookService bookService) : AppBaseController
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<ActionResult<CreateBookingResponse>> CreateBooking(
        [FromQuery] CreateBookingRequest request)
    {
        return Ok(await bookService.CreateBooking(request));
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("get-same-booking-count")]
    public async Task<ActionResult<GetSameBookingsCountResponse>> GetSimilarBookingCount(
        [FromQuery] GetSameBookingsCountRequest request)
    {
        return Ok(await bookService.GetSameBookingsCount(request));
    }
}