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

        var result = await mediator.Send(command);

        if (result.IsSuccess)
            return Ok(ApiResponse.Success(result.Value.ToString()));

        return BadRequest(ApiResponse.Error(result.Errors));
    }

    public record UserRegisterRequest(
        string Nickname,
        string Password,
        string PhoneNumber,
        string IsoRegionName);
}