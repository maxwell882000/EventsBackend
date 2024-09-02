using EventsBookingBackend.Domain.Booking.ValueObjects;
using EventsBookingBackend.Domain.Common.Entities;

namespace EventsBookingBackend.Domain.Booking.Entities;

public class Booking : BaseEntity
{
    public BookingStatus Status { get; set; } = BookingStatus.Waiting;
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public List<BookingUserOption> BookingOptions { get; set; }
    public BookingType BookingType { get; set; }
    public Guid BookingTypeId { get; set; }

    public bool IsSameBooking(List<BookingUserOption> bookingUserOptions)
    {
        return bookingUserOptions.Count == BookingOptions.Count
               && BookingOptions.All(
                   e =>
                       bookingUserOptions.Any(op =>
                           op.OptionId == e.OptionId &&
                           op.BookingOptionValue.Value == e.BookingOptionValue.Value)
               );
    }
}