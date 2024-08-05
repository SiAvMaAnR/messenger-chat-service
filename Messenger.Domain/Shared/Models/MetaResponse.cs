namespace Messenger.Domain.Shared.Models;

public class MetaResponse
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int ItemsCount { get; set; }
    public int PagesCount { get; set; }
}
