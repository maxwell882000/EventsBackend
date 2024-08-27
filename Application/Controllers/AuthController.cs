using EventsBookingBackend.Application.Common;
using EventsBookingBackend.Application.Models.Auth.Requests;
using EventsBookingBackend.Application.Models.Auth.Responses;
using EventsBookingBackend.Application.Models.Common;
using EventsBookingBackend.Application.Services.Auth;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EventsBookingBackend.Application.Controllers;

public class AuthController(IAuthService authService) : AppBaseController
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
    [HttpPost("register")]
    public async Task<ActionResult<AuthRegisterResponse>> Register(
        [FromBody] AuthRegisterRequest request
    )
    {
        var result = await authService.Register(request);
        return Created(string.Empty, result);
    }
}