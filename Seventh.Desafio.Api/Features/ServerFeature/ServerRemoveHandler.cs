using MediatR;

namespace Seventh.Desafio.Api.Features.ServerFeature;

internal class ServerRemoveHandler : IRequestHandler<ServerRemoveCommand, Boolean>
{
    public Task<bool> Handle(ServerRemoveCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

