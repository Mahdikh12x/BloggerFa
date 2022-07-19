namespace BlogManagement.Application.Contracts.Post;

public class PostViewModel
{
    public long Id { get;  set; }
    public string Title { get; set; } = null!;
    public string DateModified { get;  set; } = null!;
    public int NumberOfViews { get;  set; }
    public int NumberOfUpVotes { get;  set; }
    public long AuthorId { get; set; }
    public string? AuthorName { get; set; }
    public string PublishDate { get;  set; } = null!;
    public long CategoryId { get; set; }
}