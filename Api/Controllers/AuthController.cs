using EventsBookingBackend.Application.Common;
using EventsBookingBackend.Application.Models.Auth.Requests;
using EventsBookingBackend.Application.Models.Common;
using EventsBookingBackend.Application.Services.Auth;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using AuthenticationSchemes = System.Net.AuthenticationSchemes;

namespace EventsBookingBackend.Api.Controllers;

// [Authorize]
public class AuthController(IAuthService authService) : AppBaseController
{
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
    [HttpPost("register")]
    public async Task<SignInResult> Register(
        [FromBody] AuthRegisterRequest request
    )
    {
        var result = await authService.Register(request);
        return SignIn(result);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
    [HttpPost("login")]
    public async Task<SignInResult> Login(
        [FromBody] AuthLoginRequest request
    )
    {
        var result = await authService.Login(request);
        return SignIn(result);
    }

    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
    [HttpGet("get-user")]
    public async Task<IActionResult> GetUser()
    {
        return Ok((await authService.GetCurrentAuthUser()));
    }
}