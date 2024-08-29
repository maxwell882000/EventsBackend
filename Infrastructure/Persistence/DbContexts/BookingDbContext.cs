using EventsBookingBackend.Domain.Booking.Entities;
using EventsBookingBackend.Infrastructure.Persistence.Configurations.Booking;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.Persistence.DbContexts;

public class BookingDbContext(DbContextOptions<BookingDbContext> options) : BaseDbContext<BookingDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("bookings");
        modelBuilder.ApplyConfiguration(new BookingOptionConfiguration());
        modelBuilder.ApplyConfiguration(new BookingTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfigurations());
        modelBuilder.ApplyConfiguration(new BookingUserOptionConfiguration());
    }

    public DbSet<BookingOption> BookingOptions { get; init; }
    public DbSet<BookingType> BookingTypes { get; init; }
    public DbSet<Booking> Bookings { get; init; }
    public DbSet<BookingUserOption> BookingUserOptions { get; init; }
}