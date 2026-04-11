using FluentResults;

namespace TangyuanBackendASP.WebApi.Models;

public record ApiResponse<T>(
    string Message,
    T? Data);

public record ApiResponse(string Message)
{
    public static ApiResponse Error(string message)
    {
        return new ApiResponse(message);
    }

    public static ApiResponse Error(IEnumerable<IError> errors)
    {
        return new ApiResponse(string.Join(", ", errors.Select(e => e.Message)));
    }

    public static ApiResponse<TR> Success<TR>(TR data) => new("Success", data);

    public static ApiResponse Success() => new("Success");
}