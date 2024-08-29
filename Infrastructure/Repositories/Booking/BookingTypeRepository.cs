using EventsBookingBackend.Domain.Booking.Entities;
using EventsBookingBackend.Domain.Booking.Repositories;
using EventsBookingBackend.Infrastructure.Persistence.DbContexts;
using EventsBookingBackend.Infrastructure.Repository.Common;

namespace EventsBookingBackend.Infrastructure.Repository.Booking;

public class BookingTypeRepository(BookingDbContext context)
    : CrudRepository<BookingType, BookingDbContext>(context), IBookingTypeRepository;