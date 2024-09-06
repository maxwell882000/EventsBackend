using EventsBookingBackend.Domain.Event.Entities;
using EventsBookingBackend.Domain.Event.Repositories;
using EventsBookingBackend.Infrastructure.Persistence.DbContexts;
using EventsBookingBackend.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.Repositories.Event;

public class LikedEventRepository(EventDbContext context) : ILikedEventRepository
{
    private async Task Create(LikedEvent likedEvent)
    {
        await context.LikedEvents.AddAsync(likedEvent);
        await context.SaveChangesAsync();
    }

    public async Task Upsert(LikedEvent likedEvent)
    {
        var isExists =
            await context.LikedEvents.CountAsync(e =>
                e.EventId == likedEvent.EventId && e.UserId == likedEvent.UserId) > 0;
        if (isExists)
        {
            await Delete(likedEvent);
        }
        else
        {
            await Create(likedEvent);
        }
    }

    private async Task Delete(LikedEvent likedEvent)
    {
        await context.LikedEvents.Where(e => e.EventId == likedEvent.EventId && e.UserId == likedEvent.UserId)
            .ExecuteDeleteAsync();
    }
}