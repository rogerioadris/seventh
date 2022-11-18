using MediatR;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerCheckQuery : IRequest<Boolean>
{
    public ServerCheckQuery(Guid uid)
    {
        Uid = uid;
    }

    public Guid Uid { get; init; }
}
