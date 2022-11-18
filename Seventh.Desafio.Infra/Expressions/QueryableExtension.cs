using Seventh.Desafio.Domain.Views;

namespace Seventh.Desafio.Infra.Expressions;

internal static class QueryableExtension
{
    public async static Task<PaginationView<TEntity>> GetPaged<TEntity>(
        this IQueryable<TEntity> query,
        short page,
        byte recordPerPage,
        CancellationToken cancellation = default
    )
        where TEntity : IModel
    {
        if (page <= 0) page = 1;
        int totalRecords = await query.CountAsync(cancellation);
        int totalPages = (int)Math.Ceiling((double)totalRecords / recordPerPage);
        int skip = (page - 1) * recordPerPage;
        var data = await query.Skip(skip).Take(recordPerPage).ToListAsync(cancellation);

        return new PaginationView<TEntity>(data)
        {
            Page = page,
            RecordPerPage = recordPerPage,
            TotalPages = totalPages,
            TotalRecords = totalRecords
        };
    }
}
