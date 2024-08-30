using AutoMapper;
using EventsBookingBackend.Application.Models.Event.Responses;
using EventsBookingBackend.Application.Services.Auth;
using EventsBookingBackend.Domain.Event.Repositories;
using EventsBookingBackend.Domain.Event.Specifications;
using EventsBookingBackend.Domain.Review.Repositories;

namespace EventsBookingBackend.Application.Services.Event;

public class EventService(
    IEventRepository eventRepository,
    IMapper mapper,
    IAuthService service)
    : IEventService
{
    public async Task<IList<GetAllEventsResponse>> GetAllEvents()
    {
        var events =
            await eventRepository.FindAll(new GetAllEventsSpecification((await service.GetCurrentAuthUser()).Id));

        return mapper.Map<List<GetAllEventsResponse>>(events);
    }
}