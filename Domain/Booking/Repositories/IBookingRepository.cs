using EventsBookingBackend.Domain.Booking.Entities;
using EventsBookingBackend.Domain.Common.Repositories;

namespace EventsBookingBackend.Domain.Booking.Repositories;

public interface IBookingRepository : IBaseRepository<Entities.Booking>;