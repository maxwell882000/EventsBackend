using AutoMapper;
using EventsBookingBackend.Application.Models.Booking.Requests;
using EventsBookingBackend.Application.Models.Booking.Responses;
using EventsBookingBackend.Domain.Booking.Repositories;
using EventsBookingBackend.Domain.Booking.Specifications;

namespace EventsBookingBackend.Application.Services.Book;

public class BookService(IBookingTypeRepository bookingTypeRepository, IMapper mapper) : IBookService
{
    public async Task<GetBookingTypeByCategoryResponse> GetBookingType(GetBookingTypeByCategoryRequest request)
    {
        var bookingType = await
            bookingTypeRepository.FindFirst(new GetBookingTypeByCategorySpecification(request.CategoryId));
        return mapper.Map<GetBookingTypeByCategoryResponse>(bookingType);
    }
}