using EventsBookingBackend.Application.Models.Booking.Dto;

namespace EventsBookingBackend.Application.Models.Booking.Responses;

public class GetBookingTypeByCategoryResponse
{
    public string Label { get; set; }
    public Guid CategoryId { get; set; }
    public IList<BookingOptionDto> BookingOptions { get; set; }
}