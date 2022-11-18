using MediatR;

namespace Seventh.Desafio.Api.Features.ServerFeature;

internal class ServerCreateNotification : INotification
{
    public ServerCreateNotification(Guid uid)
    {
        Uid = uid;
    }

    public Guid Uid { get; init; }
}
