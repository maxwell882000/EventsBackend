using AutoMapper;
using EventsBookingBackend.Application.Models.Booking.Dto;
using EventsBookingBackend.Application.Models.Booking.Responses;
using EventsBookingBackend.Domain.Booking.Entities;
using EventsBookingBackend.Domain.Booking.ValueObjects;

namespace EventsBookingBackend.Application.Profiles.Booking;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<BookingType, GetBookingTypeByCategoryResponse>();
        CreateMap<BookingOption, BookingOptionDto>();
        CreateMap<BookingOptionValue, BookingOptionValueDto>();
    }
}