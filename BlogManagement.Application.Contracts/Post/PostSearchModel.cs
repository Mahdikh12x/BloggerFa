namespace BlogManagement.Application.Contracts.Post;

public class PostSearchModel
{
    public string Title { get; set; } = null!;
    public long CategoryId { get; set; }
}