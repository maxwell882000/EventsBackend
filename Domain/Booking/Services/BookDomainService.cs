using EventsBookingBackend.Domain.Booking.Entities;
using EventsBookingBackend.Domain.Booking.Repositories;
using EventsBookingBackend.Domain.Booking.Specifications;
using EventsBookingBackend.Domain.Common.Exceptions;

namespace EventsBookingBackend.Domain.Booking.Services;

public class BookDomainService(IBookingRepository bookingRepository, IBookingLimitRepository bookingLimitRepository)
    : IBookingDomainService
{
    public async Task<Entities.Booking> CreateBooking(Entities.Booking booking)
    {
        var currentLimit = await GetBookingLimit(booking);

        var bookingCount = await SameBookingsCount(booking);

        if (currentLimit != null && bookingCount >= currentLimit.MaxBookings)
        {
            throw new DomainRuleException("Количество забранированных мест достигло лимита !");
        }

        await bookingRepository.Create(booking);

        return booking;
    }

    public async Task<int> SameBookingsCount(Entities.Booking booking)
    {
        var allBookings = await bookingRepository
            .FindAll(new GetSimilarBookings(booking.EventId, booking.BookingTypeId));

        return allBookings.Count(e => e.IsSameBooking(booking.BookingOptions));
    }

    public async Task<BookingLimit?> GetBookingLimit(Entities.Booking booking)
    {
        return await bookingLimitRepository.FindFirst(new GetEventBookingLimit(booking.EventId))
               ?? await bookingLimitRepository.FindFirst(new GetDefaultBookingLimit(booking.BookingTypeId));
    }
}