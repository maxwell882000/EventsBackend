using EventsBookingBackend.Application.Models.Event.Responses;
using EventsBookingBackend.Domain.Event.Repositories;
using EventsBookingBackend.Domain.Review.Repositories;

namespace EventsBookingBackend.Application.Services.Event;

public class EventService(IEventRepository eventRepository, IReviewRepository reviewRepository) : IEventService
{
    public Task<IList<GetAllEventsResponse>> GetAllEvents()
    {
        throw new NotImplementedException();
    }
}