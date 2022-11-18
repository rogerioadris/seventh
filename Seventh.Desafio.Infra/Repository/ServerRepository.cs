namespace Seventh.Desafio.Infra.Repository;

internal class ServerRepository : BaseRepository<ServerModel>, IServerRepository
{
    public ServerRepository(SeventhContext context) : base(context)
    {
    }
}
