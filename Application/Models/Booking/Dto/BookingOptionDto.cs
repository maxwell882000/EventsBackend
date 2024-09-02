using System.ComponentModel.DataAnnotations;
using EventsBookingBackend.Domain.Booking.ValueObjects;

namespace EventsBookingBackend.Application.Models.Booking.Dto;

public class BookingOptionDto
{
    [Required] public string? Label { get; set; }
    [Required] public BookingOptionType? Type { get; set; }
    public List<BookingOptionValueDto>? BookingOptionValues { get; set; }
}