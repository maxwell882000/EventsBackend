using AutoMapper;
using EventsBookingBackend.Application.Common.Exceptions;
using EventsBookingBackend.Application.Models.Event.Requests;
using EventsBookingBackend.Application.Models.Event.Responses;
using EventsBookingBackend.Application.Services.Auth;
using EventsBookingBackend.Domain.Event.Repositories;
using EventsBookingBackend.Domain.Event.Specifications;

namespace EventsBookingBackend.Application.Services.Event;

public class EventService(
    IEventRepository eventRepository,
    IMapper mapper,
    IAuthService authService)
    : IEventService
{
    public async Task<IList<GetAllEventsResponse>> GetAllEvents()
    {
        var events =
            await eventRepository.FindAll(new GetAllEventsSpecification(authService.GetCurrentAuthUserId()));
        return mapper.Map<List<GetAllEventsResponse>>(events);
    }

    public async Task<GetEventDetailResponse> GetEventDetail(GetEventDetailRequest request)
    {
        var @event =
            await eventRepository.FindFirst(
                new GetEventByIdSpecification(request.Id, authService.GetCurrentAuthUserId()));
        if (@event == null)
            throw new AppValidationException("Эвент не найден !");
        return mapper.Map<GetEventDetailResponse>(@event);
    }
}