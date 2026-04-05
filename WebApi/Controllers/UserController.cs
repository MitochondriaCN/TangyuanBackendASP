using MediatR;
using Microsoft.AspNetCore.Mvc;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.WebApi.Models;

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

        var userId = await mediator.Send(command);
        return Ok(ApiResponse.Success(userId.ToString()));
    }

    public record UserRegisterRequest(
        string Nickname,
        string Password,
        string PhoneNumber,
        string IsoRegionName);
}