using EventsBookingBackend.Application.Common;
using EventsBookingBackend.Application.Models.User.Responses;
using EventsBookingBackend.Application.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsBookingBackend.Api.Controllers;

[Authorize]
public class ProfileController(IUserService userService) : AppBaseController
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("get-user-profile")]
    public async Task<ActionResult<GetUserProfileResponse>> GetEventDetail()
    {
        var user = await userService.GetUserProfile();
        return Ok(user);
    }
}