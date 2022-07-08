using _0_Framework.Domain;
using BlogManagement.Domain.PostAgg;

namespace BlogManagement.Domain.PostCategoryAgg
{
    public class PostCategory:BaseEntityWithSeoTags<long>
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public string? Picture { get;private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get;  private set; }
        public ICollection<Post>? Posts { get; protected set; }

        protected PostCategory()
        {

        }
        public PostCategory(string metaDescription, string keywords, string slug, string? canonicalAddress, string name, string description, string? picture, string? pictureAlt, string? pictureTitle) : base(metaDescription, keywords, slug, canonicalAddress)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Edit(string metaDescription, string keywords, string slug, string? canonicalAddress, string name, string description, string? picture, string? pictureAlt, string? pictureTitle) 
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            base.Edit(metaDescription,keywords, slug, canonicalAddress);
        }
    }
}
