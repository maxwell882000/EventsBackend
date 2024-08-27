using EventsBookingBackend.Domain.Common.Repositories;
using EventsBookingBackend.Domain.Event.Entities;

namespace EventsBookingBackend.Domain.Event.Repositories;

public interface ILikedEventRepository
{
    public Task<LikedEvent> Create(LikedEvent likedEvent);
    public Task Delete(LikedEvent likedEvent);
}