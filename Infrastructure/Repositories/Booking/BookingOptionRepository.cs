using EventsBookingBackend.Domain.Booking.Entities;
using EventsBookingBackend.Domain.Booking.Repositories;
using EventsBookingBackend.Domain.Common.Repositories;
using EventsBookingBackend.Infrastructure.Persistence.DbContexts;
using EventsBookingBackend.Infrastructure.Repository.Common;

namespace EventsBookingBackend.Infrastructure.Repository.Booking;

public class BookingOptionRepository(BookingDbContext context)
    : CrudRepository<BookingOption, BookingDbContext>(context), IBookingOptionRepository;