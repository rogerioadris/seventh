using Seventh.Desafio.Domain.Models;
using Seventh.Desafio.Domain.Views;

namespace Seventh.Desafio.Domain.Interfaces.Repository;

public interface IBaseRepository<TEntity> where TEntity : IModel
{
    Task<Boolean> AnyAsync(Guid uid, CancellationToken cancellationToken = default);

    Task<TEntity?> GetAsync(Guid uid, CancellationToken cancellation = default);

    Task<PaginationView<TEntity>> GetPagedAsync(short page, byte records, CancellationToken cancellation = default);

    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Boolean> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<Boolean> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<Boolean> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
}