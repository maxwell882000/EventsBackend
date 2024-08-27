using EventsBookingBackend.Domain.Booking.Entities;
using EventsBookingBackend.Domain.Booking.Repositories;
using EventsBookingBackend.Infrastructure.EntityFramework.DbContexts;
using EventsBookingBackend.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace EventsBookingBackend.Infrastructure.Repository.Booking;

public class BookingRepository(BookingDbContext context)
    : CrudRepository<Domain.Booking.Entities.Booking, BookingDbContext>(context), IBookingRepository
{
    public Task<List<Domain.Booking.Entities.Booking>> GetUserBookings(Guid userId)
    {
        return DbSet.Where(b => b.UserId == userId).AsNoTracking().ToListAsync();
    }
}