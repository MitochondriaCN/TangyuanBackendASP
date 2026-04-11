namespace TangyuanBackendASP.Application.Dtos;

public record PostDto(
    long Id,
    long UserId,
    DateTime PostDateTime,
    long CategoryId,
    string TextContent,
    bool IsVisible,
    params string[] ImageGuids
);