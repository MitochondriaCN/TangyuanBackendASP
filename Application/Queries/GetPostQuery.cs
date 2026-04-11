using MediatR;
using TangyuanBackendASP.Application.Dtos;

namespace TangyuanBackendASP.Application.Queries;

public record GetPostQuery(
    long Id
) : IRequest<PostDto?>;