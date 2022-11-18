using MediatR;
using Seventh.Desafio.Domain.Interfaces.Repository;
using Seventh.Desafio.Domain.Models;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerDeleteHandler : IRequestHandler<ServerDeleteCommand, Boolean>
{
    private readonly IServerRepository _repository;

    private readonly IPublisher _publisher;

    public ServerDeleteHandler(IServerRepository repository, IPublisher publisher)
    {
        _repository = repository;
        _publisher = publisher;
    }

    public async Task<bool> Handle(ServerDeleteCommand request, CancellationToken cancellationToken)
    {
        var model = await _repository.GetAsync(request.Uid, cancellationToken);
        if (model != null && await _repository.DeleteAsync(model, cancellationToken))
        {
            await _publisher.Publish(new ServerDeleteNotification(model), cancellationToken);
            return true;
        }
        return false;
    }
}
