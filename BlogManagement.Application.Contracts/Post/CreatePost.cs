using _0_Framework.Application;
using BlogManagement.Application.Contracts.PostCategory;

namespace BlogManagement.Application.Contracts.Post;

public class CreatePost:SeoTags
{
    public string Title { get;  set; } = null!;
    public string Content { get;  set; } = null!;
    public string Link { get; set; } = null!;
    public string ShortDescription { get;  set; } = null!;
    public string PublishDate { get;  set; } = null!;
    public string Picture { get;  set; } = null!;
    public string PictureAlt { get;  set; } = null!;
    public string PictureTitle { get;  set; } = null!;
    public long CategoryId { get; set; }
    public int StudyTime { get; set; }
    public IEnumerable<PostCategorySelectList>? PostCategoryLists{ get; set; }

}