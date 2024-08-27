using EventsBookingBackend.Domain.Booking.Entities;
using EventsBookingBackend.Infrastructure.EntityFramework.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsBookingBackend.Infrastructure.EntityFramework.Configurations.Booking;

public class BookingUserOptionConfiguration : BaseEntityConfiguration<BookingUserOption>
{
    public override void Configure(EntityTypeBuilder<BookingUserOption> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(e => e.BookingOptionValue).WithOwner();
        builder.HasOne(e => e.Option).WithMany().HasForeignKey(e => e.OptionId);
    }
}