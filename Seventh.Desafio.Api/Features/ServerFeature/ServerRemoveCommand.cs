
using MediatR;

namespace Seventh.Desafio.Api.Features.ServerFeature;

internal class ServerRemoveCommand : IRequest<Boolean>
{
    public ServerRemoveCommand(Guid uid)
    {
        Uid = uid;
    }

    public Guid Uid { get; init; }
}
