using System.Net.Sockets;
using MediatR;
using Seventh.Desafio.Domain.Interfaces.Repository;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerCheckHandler : IRequestHandler<ServerCheckQuery, Boolean>
{
    private readonly IServerRepository _repository;

    public ServerCheckHandler(IServerRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(ServerCheckQuery request, CancellationToken cancellationToken)
    {
        var model = await _repository.GetAsync(request.Uid, cancellationToken);
        if (model != null && model.IpAddress != null)
        {
            TcpClient? client = null;
            try
            {
                client = new TcpClient(model.IpAddress!, model.Port!);
                return client.Connected;
            }
            catch (SocketException)
            {

            }
            finally
            {
                client?.Close();
            }
        }

        return false;
    }
}
