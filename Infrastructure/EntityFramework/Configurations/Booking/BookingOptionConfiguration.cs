using EventsBookingBackend.Domain.Booking.Entities;
using EventsBookingBackend.Domain.Booking.ValueObjects;
using EventsBookingBackend.Infrastructure.EntityFramework.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBookingBackend.Infrastructure.EntityFramework.Configurations.Booking;

public class BookingOptionConfiguration : BaseEntityConfiguration<BookingOption>
{
    public override void Configure(EntityTypeBuilder<BookingOption> builder)
    {
        base.Configure(builder);

        builder.OwnsMany(e => e.BookingOptionValues).WithOwner();
        builder.Property(e => e.Type).HasConversion<string>();
    }
}