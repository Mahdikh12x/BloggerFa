using _0_Framework.Application;

namespace BlogManagement.Application.Contracts.PostCategory;

public class CreatePostCategory:SeoTags
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Picture { get; set; }
    public string? PictureAlt { get; set; }
    public string? PictureTitle { get; set; }
}