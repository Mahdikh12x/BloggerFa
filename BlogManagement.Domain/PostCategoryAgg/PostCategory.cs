using _0_Framework.Domain;
using BlogManagement.Domain.PostAgg;

namespace BlogManagement.Domain.PostCategoryAgg
{
    public class PostCategory:BaseEntity<long>
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public string? Picture { get;private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get;  private set; }
          public string Keywords { get; private set; } = null!;
        public string MetaDescription { get; private set; } = null!;
        public string? CanonicalAddress { get; private set; }
        public string Slug { get; private set; } = null!;

        public ICollection<Post>? Posts { get; protected set; }

        protected PostCategory()
        {

        }
        public PostCategory(string metaDescription, string keywords, string slug, string? canonicalAddress, string name, string description, string? picture, string? pictureAlt, string? pictureTitle) 
        {
            Name = name;
            Description = description;
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
            CanonicalAddress = canonicalAddress;
        }

        public void Edit(string metaDescription, string keywords, string slug, string? canonicalAddress, string name, string description, string? picture, string? pictureAlt, string? pictureTitle) 
        {
            Name = name;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
            CanonicalAddress = canonicalAddress;
            ModifiedDate=DateTime.Now;
        }
    }
}
