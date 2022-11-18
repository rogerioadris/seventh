using MediatR;
using Seventh.Desafio.Domain.Models;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerDeleteNotification : INotification
{
    public ServerDeleteNotification(ServerModel model)
    {
        this.model = model;
    }

    public ServerModel model { get; init; }
}
