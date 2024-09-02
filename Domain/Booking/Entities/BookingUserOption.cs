using EventsBookingBackend.Domain.Booking.ValueObjects;
using EventsBookingBackend.Domain.Common.Entities;

namespace EventsBookingBackend.Domain.Booking.Entities;

public class BookingUserOption : BaseEntity
{
    public BookingOption Option { get; set; }
    public BookingOptionValue BookingOptionValue { get; set; }
    public Guid BookingId { get; set; }
    public Guid OptionId { get; set; }
}