using Messenger.Domain.Entities;
using Messenger.Domain.Shared.Models;

namespace Messenger.Application.Services.Common;

public class PaginatorResponse<TEntity>(IEnumerable<TEntity> collection, MetaResponse meta)
{
    public IEnumerable<TEntity> Collection { get; set; } = collection;
    public MetaResponse Meta { get; set; } = meta;
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
        int skip = pagination?.Skip ?? 0;
        int pageSize = pagination?.PageSize ?? itemCount;
        int pageNumber = pagination?.PageNumber ?? 0;
        int pagesCount = pageSize > 0 ? (int)Math.Ceiling((float)itemCount / pageSize) : 0;

        IEnumerable<TEntity>? pagedCollection =
            pagination != null
                ? collection.Skip(pageNumber * pageSize + skip).Take(pageSize)
                : collection;

        var meta = new MetaResponse()
        {
            ItemsCount = itemCount,
            PagesCount = pagesCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        return new PaginatorResponse<TEntity>(pagedCollection, meta);
    }
}
