using MediatR;
using Seventh.Desafio.Domain.Interfaces.Repository;
using Seventh.Desafio.Domain.Models;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerFindHandler : IRequestHandler<ServerFindQuery, ServerModel?>
{
    private readonly IServerRepository _repository;

    public ServerFindHandler(IServerRepository repository)
    {
        _repository = repository;
    }

    public Task<ServerModel?> Handle(ServerFindQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAsync(request.Uid, cancellationToken);
    }
}
