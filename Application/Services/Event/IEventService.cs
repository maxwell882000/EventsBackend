using EventsBookingBackend.Application.Models.Event.Responses;

namespace EventsBookingBackend.Application.Services.Event;

public interface IEventService
{
    public Task<IList<GetAllEventsResponse>> GetAllEvents();
}