using MediatR;
using Seventh.Desafio.Domain.Interfaces.Repository;
using Seventh.Desafio.Domain.Models;
using Seventh.Desafio.Domain.Views;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerPaginationHandler : IRequestHandler<ServerPaginationQuery, PaginationView<ServerModel>>
{
    private readonly IServerRepository _repository;

    public ServerPaginationHandler(IServerRepository repository)
    {
        _repository = repository;
    }

    public Task<PaginationView<ServerModel>> Handle(ServerPaginationQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetPagedAsync(request.Page, request.Records, cancellationToken);
    }
}
