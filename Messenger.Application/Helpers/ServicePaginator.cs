using MessengerX.Domain.Entities;
using MessengerX.Domain.Shared.Models;

namespace MessengerX.Application.Services.Helpers;

public class PaginatorResponse<TEntity>
{
    public MetaResponse Meta { get; set; } = null!;
    public IEnumerable<TEntity> Collection { get; set; } = null!;
}

public static class ServicePaginator
{
    public static PaginatorResponse<TEntity> Pagination<TEntity>(
        this IEnumerable<TEntity> collection,
        Pagination? pagination
    )
        where TEntity : BaseEntity
    {
        int itemCount = collection.Count();
        int pageSize = pagination?.PageSize ?? itemCount;
        int pageNumber = pagination?.PageNumber ?? 0;
        int pagesCount = pagination != null ? (int)Math.Ceiling((float)itemCount / pageSize) : 1;

        IEnumerable<TEntity>? pagedCollection =
            pagination != null ? collection.Skip(pageNumber * pageSize).Take(pageSize) : collection;

        return new PaginatorResponse<TEntity>
        {
            Collection = pagedCollection,
            Meta = new MetaResponse()
            {
                ItemsCount = itemCount,
                PagesCount = pagesCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            },
        };
    }
}
