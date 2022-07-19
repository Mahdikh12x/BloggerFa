using BlogManagement.Application.Contracts.Post;

namespace BlogManagement.Application.Contracts.Tag;

public class CreateTag
{
    public string Name { get; set; } = null!;
    public ICollection<PostViewModel>? Posts { get; set; }
}