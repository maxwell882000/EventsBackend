using EventsBookingBackend.Domain.Booking.ValueObjects;
using EventsBookingBackend.Domain.Common.Entities;

namespace EventsBookingBackend.Domain.Booking.Entities;

public class Booking : BaseEntity
{
    public BookingStatus Status { get; set; }
    public decimal Cost { get; set; }
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public List<BookingUserOption> BookingOptions { get; set; }
    public BookingType BookingType { get; set; }
    public Guid BookingTypeId { get; set; }
}