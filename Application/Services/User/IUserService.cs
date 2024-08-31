using EventsBookingBackend.Application.Models.User.Responses;

namespace EventsBookingBackend.Application.Services.User;

public interface IUserService
{
    public Task<GetUserProfileResponse> GetUserProfile();
}