using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.WebApi.Models;
using TangyuanBackendASP.WebApi.Utils;

namespace TangyuanBackendASP.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IMediator mediator) : Controller
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        var command = new CreateUserCommand(
            Password: request.Password,
            Nickname: request.Nickname,
            PhoneNumber: request.PhoneNumber,
            IsoRegionName: request.IsoRegionName);

        var result = await mediator.Send(command);

        if (result.IsSuccess)
            return Ok(ApiResponse.Success(result.Value.ToString()));

        return BadRequest(ApiResponse.Error(result.Errors));
    }

    [Authorize]
    [HttpPost("update/{userId:long}")]
    public async Task<IActionResult> Update([FromRoute] long userId, [FromBody] UpdateUserRequest request)
    {
        var currentUserId = HttpContext.User.GetUserId();
        if (currentUserId != userId)
            return BadRequest(ApiResponse.Error("您无权更新其他用户的个人信息"));

        var command = new UpdateUserCommand(
            UserId: currentUserId,
            Nickname: request.Nickname,
            AvatarGuid: request.AvatarGuid,
            Bio: request.Bio,
            PhoneNumber: request.PhoneNumber,
            Email: request.Email);

        var result = await mediator.Send(command);
        if (result.IsSuccess)
            return Ok(ApiResponse.Success());

        return BadRequest(ApiResponse.Error(result.Errors));
    }

    public record UserRegisterRequest(
        string Nickname,
        string Password,
        string PhoneNumber,
        string IsoRegionName);

    public record UpdateUserRequest(
        string? Nickname,
        string? AvatarGuid,
        string? Bio,
        string? PhoneNumber,
        string? Email);
}