using EventsBookingBackend.Domain.Booking.Entities;
using EventsBookingBackend.Infrastructure.EntityFramework.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBookingBackend.Infrastructure.EntityFramework.Configurations.Booking;

public class BookingTypeConfiguration : BaseEntityConfiguration<BookingType>
{
    public override void Configure(EntityTypeBuilder<BookingType> builder)
    {
        base.Configure(builder);

    }
}