using MediatR;
using Seventh.Desafio.Domain.Models;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerCreateCommand : IRequest<ServerModel>
{
    public ServerCreateCommand(string name, string ipAddress, int port)
    {
        Name = name;
        IpAddress = ipAddress;
        Port = port;
    }

    public String Name { get; init; } = String.Empty;

    public String IpAddress { get; init; } = String.Empty;

    public Int32 Port { get; init; }
}
