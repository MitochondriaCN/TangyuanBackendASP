namespace TangyuanBackendASP.WebApi.Models;

public record ApiResponse<T>(
    int Code,
    string Message,
    T? Data);

public static class ApiResponse
{
    public static ApiResponse<TR> Success<TR>(TR data) => new(200, "Success", data);
}