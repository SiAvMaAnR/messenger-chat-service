namespace Messenger.Domain.Shared.Models;

public class Pagination
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int? Skip { get; set; }
}
