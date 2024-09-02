using EventsBookingBackend.Domain.Booking.Repositories;
using EventsBookingBackend.Domain.Booking.Specifications;
using EventsBookingBackend.Domain.Common.Exceptions;

namespace EventsBookingBackend.Domain.Booking.Services;

public class BookDomainService(IBookingRepository bookingRepository, IBookingLimitRepository bookingLimitRepository)
    : IBookingDomainService
{
    public async Task<Entities.Booking> MakeBooking(Entities.Booking booking)
    {
        var currentLimit = await bookingLimitRepository.FindFirst(new GetEventBookingLimit(booking.EventId))
                           ?? await bookingLimitRepository.FindFirst(new GetDefaultBookingLimit(booking.BookingTypeId));

        var allBookings = await bookingRepository
            .FindAll(new GetSimilarBookings(booking.EventId, booking.BookingTypeId));
        var bookingCount = allBookings.Count(e => e.IsSameBooking(booking.BookingOptions));

        if (currentLimit != null && bookingCount >= currentLimit.MaxBookings)
        {
            throw new DomainRuleException("Количество забранированных мест достигло лимита !");
        }

        await bookingRepository.Create(booking);

        return booking;
    }
}