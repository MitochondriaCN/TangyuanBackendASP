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
            request.CategoryId,
            request.TextContent,
            request.ImageGuids ?? []);

        var result = await mediator.Send(command, cancellationToken);

        if (result.IsSuccess)
            return Ok(ApiResponse.Success(result.Value.ToString()));

        return BadRequest(ApiResponse.Error(result.Errors));
    }

    [Authorize]
    [HttpDelete("delete/{postId:long}")]
    public async Task<IActionResult> DeletePost(long postId)
    {
        var userId = HttpContext.User.GetUserId();
        var command = new DeletePostCommand(postId, userId);

        var result = await mediator.Send(command);

        if (result.IsSuccess)
            return Ok(ApiResponse.Success());

        return BadRequest(ApiResponse.Error(result.Errors));
    }

    public record CreatePostRequest(
        long CategoryId,
        string TextContent,
        string[]? ImageGuids
    );
}