using EventsBookingBackend.Domain.Booking.ValueObjects;
using EventsBookingBackend.Domain.Common.Entities;

namespace EventsBookingBackend.Domain.Booking.Entities;

public class BookingUserOption : BaseEntity
{
    public BookingOption Option { get; set; }
    public BookingOptionValue? BookingOptionValue { get; set; } // for DROP DOWN
    public string? Value { get; set; } // for INPUT
    public Guid BookingId { get; set; }
    public Guid OptionId { get; set; }
}