using EventsBookingBackend.Domain.Event.Entities;
using EventsBookingBackend.Domain.Event.Repositories;
using EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;
using EventsBookingBackend.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.Repository.Event;

public class LikedEventRepository(EventDbContext context) : ILikedEventRepository
{
    public async Task<LikedEvent> Create(LikedEvent likedEvent)
    {
        await context.LikedEvents.AddAsync(likedEvent);
        await context.SaveChangesAsync();
        return likedEvent;
    }

    public async Task Delete(LikedEvent likedEvent)
    {
        await context.LikedEvents.Where(e => e.Id == likedEvent.Id).ExecuteUpdateAsync(setPropertyCalls =>
            setPropertyCalls.SetProperty(e => e.IsDeleted, true));
    }
}