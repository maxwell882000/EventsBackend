using EventsBookingBackend.Domain.Common.Specifications;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Domain.Booking.Specifications;

public class GetUserBookings(Guid userId) : ISpecification<Entities.Booking>
{
    public IQueryable<Entities.Booking> Apply(IQueryable<Entities.Booking> query)
    {
        return query.Where(b => b.UserId == userId).AsNoTracking();
    }
}