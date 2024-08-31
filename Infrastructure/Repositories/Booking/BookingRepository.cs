using EventsBookingBackend.Domain.Booking.Entities;
using EventsBookingBackend.Domain.Booking.Repositories;
using EventsBookingBackend.Infrastructure.Persistence.DbContexts;
using EventsBookingBackend.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.Repositories.Booking;

public class BookingRepository(BookingDbContext context)
    : BaseRepository<Domain.Booking.Entities.Booking, BookingDbContext>(context), IBookingRepository
{
    public Task<List<Domain.Booking.Entities.Booking>> GetUserBookings(Guid userId)
    {
        return DbSet.Where(b => b.UserId == userId).AsNoTracking().ToListAsync();
    }
}