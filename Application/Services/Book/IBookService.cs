using EventsBookingBackend.Application.Models.Booking.Requests;
using EventsBookingBackend.Application.Models.Booking.Responses;

namespace EventsBookingBackend.Application.Services.Book;

public interface IBookService
{
    public Task<GetBookingTypeByCategoryResponse> GetBookingType(GetBookingTypeByCategoryRequest request);
}