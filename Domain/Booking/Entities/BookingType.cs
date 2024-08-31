using EventsBookingBackend.Domain.Common.Entities;

namespace EventsBookingBackend.Domain.Booking.Entities;

public class BookingType : BaseEntity
{
    public string Label { get; set; }
    public Guid CategoryId { get; set; }
    public IList<BookingOption> BookingOptions { get; set; }
}