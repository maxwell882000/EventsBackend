using AutoMapper;
using EventsBookingBackend.Application.Models.User.Responses;
using EventsBookingBackend.Application.Services.Auth;
using EventsBookingBackend.Domain.User.Repositories;
using EventsBookingBackend.Domain.User.Specifactions;

namespace EventsBookingBackend.Application.Services.User;

public class UserService(IUserRepository userRepository, IAuthService authService, IMapper mapper) : IUserService
{
    public async Task<GetUserProfileResponse> GetUserProfile()
    {
        var userId = (Guid)authService.GetCurrentAuthUserId()!;
        return mapper.Map<GetUserProfileResponse>(
            await userRepository.FindFirst(new GetUserProfileSpecification(userId)));
    }
}