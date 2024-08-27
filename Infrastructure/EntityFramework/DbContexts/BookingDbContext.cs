using EventsBookingBackend.Domain.Booking.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;

public class BookingDbContext(DbContextOptions<BookingDbContext> options)  : BaseDbContext<BookingDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("booking");
    }

    public DbSet<BookingOption> BookingOptions { get; init; }
    public DbSet<BookingType> BookingTypes { get; init; }
    public DbSet<Booking> Bookings { get; init; }
    public DbSet<BookingUserOption> BookingUserOptions { get; init; }
}