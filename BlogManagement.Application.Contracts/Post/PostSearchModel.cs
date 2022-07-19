namespace BlogManagement.Application.Contracts.Post;

public class PostSearchModel
{
    public string? Title { get; set; } 
    public long CategoryId { get; set; }
    private bool IsActive { get; set; }
    public string? AuthorName { get; set; }
}