namespace EventsBookingBackend.Domain.Booking.Services;

public interface IBookingDomainService
{
    public Task<Entities.Booking> MakeBooking(Entities.Booking booking);
}