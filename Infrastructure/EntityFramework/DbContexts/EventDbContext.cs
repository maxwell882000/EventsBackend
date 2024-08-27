using EventsBookingBackend.Domain.Event.Entities;
using EventsBookingBackend.Domain.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;

public class EventDbContext(DbContextOptions<EventDbContext> options)  : BaseDbContext<EventDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("events");
    }

    public DbSet<Event> Events { get; init; }
    public DbSet<LikedEvent> LikedEvents { get; init; }
}