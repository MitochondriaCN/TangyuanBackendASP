using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Posts.Dtos;

public record PostDto(
    long Id,
    long UserId,
    DateTime PostDateTime,
    long CategoryId,
    string TextContent,
    bool IsVisible,
    params string[] ImageGuids
);