using EventsBookingBackend.Application.Models.Auth.Requests;
using EventsBookingBackend.Application.Models.Auth.Responses;

namespace EventsBookingBackend.Application.Services.Auth;

public interface IAuthService
{
    public Task<AuthRegisterResponse> Register(AuthRegisterRequest request);
}