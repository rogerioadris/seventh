using Seventh.Desafio.Domain.Views;
using Seventh.Desafio.Infra.Expressions;

namespace Seventh.Desafio.Infra.Repository;

internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IModel
{
    protected readonly DbContext _context;

    protected readonly IQueryable<TEntity> _queryable;

    protected BaseRepository(DbContext context) : this(context, null) { }

    protected BaseRepository(DbContext context, IQueryable<TEntity>? queryable)
    {
        _context = context;
        _queryable = queryable ?? context.Set<TEntity>().AsQueryable();
    }

    public virtual Task<bool> AnyAsync(Guid uid, CancellationToken cancellationToken = default)
        => _queryable.AnyAsync(f => f.Uid == uid);

    public virtual async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Attach(entity);
        _context.Set<TEntity>().Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TEntity?> GetAsync(Guid uid, CancellationToken cancellation = default)
        => _queryable.SingleOrDefaultAsync(f => f.Uid == uid, cancellation);

    public Task<PaginationView<TEntity>> GetPagedAsync(short page, byte records, CancellationToken cancellation = default)
        => _queryable.GetPaged(page, records, cancellation);

    public virtual async Task<bool> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(entity, cancellationToken);
        bool result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return result;
    }

    public virtual Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
