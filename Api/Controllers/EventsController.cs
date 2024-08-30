using EventsBookingBackend.Application.Common;
using EventsBookingBackend.Application.Models.Common;
using EventsBookingBackend.Application.Models.Event.Responses;
using EventsBookingBackend.Application.Services.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsBookingBackend.Api.Controllers;

[Authorize]
public class EventsController(IEventService eventService) : AppBaseController
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("get-all-events")]
    public async Task<ActionResult<IList<GetAllEventsResponse>>> GetAllEvents()
    {
        return Ok(await eventService.GetAllEvents());
    }
}