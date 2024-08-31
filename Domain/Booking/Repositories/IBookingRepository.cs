using EventsBookingBackend.Domain.Common.Repositories;

namespace EventsBookingBackend.Domain.Booking.Repositories;

public interface IBookingRepository : IBaseRepository<Entities.Booking>
{
    public Task<List<Entities.Booking>> GetUserBookings(Guid userId);
}