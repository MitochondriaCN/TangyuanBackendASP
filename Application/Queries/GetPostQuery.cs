using MediatR;
using TangyuanBackendASP.Application.Dtos;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Queries;

public record GetPostQuery(
    long Id
) : IRequest<PostDto>;