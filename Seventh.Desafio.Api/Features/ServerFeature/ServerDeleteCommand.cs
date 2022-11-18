using MediatR;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerDeleteCommand : IRequest<Boolean>
{
    public ServerDeleteCommand(Guid uid)
    {
        Uid = uid;
    }

    public Guid Uid { get; init; }
}
