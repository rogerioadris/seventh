using MediatR;
using Seventh.Desafio.Domain.Models;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerFindQuery : IRequest<ServerModel?>
{
    public ServerFindQuery(Guid uid)
    {
        Uid = uid;
    }

    public Guid Uid { get; init; }
}
