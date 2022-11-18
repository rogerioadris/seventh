using MediatR;
using Seventh.Desafio.Domain.Models;
using Seventh.Desafio.Domain.Views;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerPaginationQuery : IRequest<PaginationView<ServerModel>>
{
    public ServerPaginationQuery() : this(1, 100)
    {
    }

    public ServerPaginationQuery(short page, byte records)
    {
        Page = page > 0 ? page : (short)1;
        Records = records > 0 ? records : (byte)100;
    }

    public Int16 Page { get; init; } = 1;

    public Byte Records { get; init; } = 100;
}
