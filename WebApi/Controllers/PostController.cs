using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.WebApi.Models;
using TangyuanBackendASP.WebApi.Utils;

namespace TangyuanBackendASP.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController(IMediator mediator) : Controller
{
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request,
        CancellationToken cancellationToken)
    {
        var userId = HttpContext.User.GetUserId();

        var command = new CreatePostCommand(
            userId,
            DateTime.Now,
            request.CategoryId,
            request.TextContent,
            request.ImageGuids ?? []);

        var postId = await mediator.Send(command, cancellationToken);
        return Ok(ApiResponse.Success(postId.ToString()));
    }

    public record CreatePostRequest(
        long CategoryId,
        string TextContent,
        string[]? ImageGuids
    );
}