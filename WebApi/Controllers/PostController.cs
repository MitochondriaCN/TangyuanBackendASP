using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TangyuanBackendASP.Application.Posts.Commands;
using TangyuanBackendASP.Domain.Entities;

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
        var command = new CreatePostCommand(
            request.UserId,
            request.PostDateTime,
            request.CategoryId,
            request.TextContent,
            request.ImageGuids ?? []);

        var postId = await mediator.Send(command, cancellationToken);
        return Ok(new { PostId = postId });
    }

    public record CreatePostRequest(
        long UserId,
        DateTime PostDateTime,
        long CategoryId,
        string TextContent,
        string[]? ImageGuids
    );
}