using MediatR;
using TangyuanBackendASP.Application.Dtos;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Application.Queries;

namespace TangyuanBackendASP.Application.Handlers;

public class GetPostQueryHandler(
    IPostQueries queries) : IRequestHandler<GetPostQuery, PostDto?>
{
    public Task<PostDto?> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        return queries.GetByIdAsync(request.Id, cancellationToken);
    }
}