using AutoMapper;
using EventsBookingBackend.Application.Models.User.Responses;

namespace EventsBookingBackend.Application.Profiles.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Domain.User.Entities.User, GetUserProfileResponse>();
    }
}