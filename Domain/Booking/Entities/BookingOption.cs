using EventsBookingBackend.Domain.Booking.ValueObjects;
using EventsBookingBackend.Domain.Common.Entities;

namespace EventsBookingBackend.Domain.Booking.Entities;

public class BookingOption : BaseEntity
{
    public string Label { get; set; }
    public BookingOptionType Type { get; set; }
    public List<BookingOptionValue>? BookingOptionValues { get; set; }
    public BookingType BookingType { get; set; }
}