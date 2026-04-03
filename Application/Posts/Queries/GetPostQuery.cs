using MediatR;
using TangyuanBackendASP.Application.Posts.Dtos;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Posts.Queries;

public record GetPostQuery(
    long Id
) : IRequest<PostDto>;