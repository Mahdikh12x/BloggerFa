using _0_Framework.Domain;
using BlogManagement.Domain.PostCategoryAgg;
using BlogManagement.Domain.TagAgg;

namespace BlogManagement.Domain.PostAgg
{
    public class Post : BaseEntity<long>
    {


        public string Title { get; private set; } = null!;
        public string Content { get; private set; } = null!;
        //public bool Flag { get; private set; }
        public int NumberOfViews { get; private set; }
        public int NumberOfUpVotes { get; private set; }
        public string? Link { get; private set; }
        public long UserId { get; private set; }
        public string ShortDescription { get; private set; } = null!;
        public DateTime PublishDate { get; private set; }
        public string? Picture { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public long CategoryId { get; private set; }
        public bool IsActive { get; private set; }
        public int StudyTime { get; private set; }
        public string Keywords { get; private set; } = null!;
        public string MetaDescription { get; private set; } = null!;
        public string? CanonicalAddress { get; private set; }
        public string Slug { get; private set; } = null!;

        public ICollection<Tag>? Tags { get; private set; }
        public PostCategory? PostCategory { get; private set; }

        public Post()
        {

        }

        public Post(string title, string content, string? link, long userId, string shortDescription, DateTime publishDate, string? picture, string? pictureAlt, string? pictureTitle, long categoryId, int studyTime, string keywords, string metaDescription, string? canonicalAddress)
        {
            Title = title;
            Content = content;
            Link = link;
            UserId = userId;
            ShortDescription = shortDescription;
            PublishDate = publishDate;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            StudyTime = studyTime;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            IsActive = false;
            NumberOfUpVotes = 0;
            NumberOfViews = 0;

        }

        public void Edit(string metaDescription, string keywords, string slug
            , string canonicalAddress, string title, string content, string link, long userId, string shortDescription
            , DateTime publishDate, string picture, string pictureAlt, string pictureTitle, long categoryId, int studyTime)

        {
            Title = title;
            Content = content;
            Link = link;
            UserId = userId;
            ShortDescription = shortDescription;
            PublishDate = publishDate;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            StudyTime = studyTime;
            MetaDescription = metaDescription;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
            Slug = slug;
            ModifiedDate = DateTime.Now;

        }

        public void Active()
        {
            IsActive = true;
        }

        public void DeActive()
        {
            IsActive = false;
        }
        //public void Flagged()
        //{
        //    Flag = true;
        //}

        public int NoOfViews() => NumberOfViews++;
        public int IncreaseNoOfUpVotes() => NumberOfUpVotes++;
        public int DecreaseNoOfUpVotes() => NumberOfUpVotes--;
    }
}
