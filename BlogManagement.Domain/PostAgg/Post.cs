using _0_Framework.Domain;
using BlogManagement.Domain.PostCategoryAgg;

namespace BlogManagement.Domain.PostAgg
{
    public class Post:BaseEntityWithSeoTags<long>
    {
        public string Title { get; private set; } = null!;
        public string Content { get; private set; } = null!;
        //public bool Flag { get; private set; }
        public DateTime DateModified { get; private set; }
        public int NumberOfViews { get; private set; }
        public int NumberOfUpVotes { get; private set; }
        public string? Link { get; set; }
        public long UserId { get; set; }
        public string ShortDescription { get; private set; } = null!;
        public DateTime PublishDate { get; private set; }
        public string? Picture { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public long CategoryId { get; private set; }
        public bool IsActive { get; private set; }
        public int StudyTime { get; private set; }
        public PostCategory? PostCategory { get; private set; }

        protected Post() 
        {
            
        }

        public Post(string metaDescription, string keywords, string slug
            , string canonicalAddress, string title, string content, string link,long userId, string shortDescription
            , DateTime publishDate, string picture, string pictureAlt, string pictureTitle, long categoryId, int studyTime)
            : base(metaDescription, keywords, slug, canonicalAddress)
        {
            Title = title;
            Content = content;
            Link = link;
            UserId = userId;
            ShortDescription = shortDescription;
            PublishDate = publishDate;
            if(!string.IsNullOrWhiteSpace(picture))
             Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            StudyTime = studyTime;
            //Flag = false;
            DateModified = DateTime.Now;
            NumberOfViews = 0;
            NumberOfUpVotes = 0;
            IsActive = false;
        }

        public void  Edit(string metaDescription, string keywords, string slug
            , string canonicalAddress, string title, string content, string link,long userId, string shortDescription
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
            //Flag = false;
            DateModified = DateTime.Now;
            base.Edit(metaDescription, keywords, slug, canonicalAddress);

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

          public  int NoOfViews() => NumberOfViews ++;
          public int IncreaseNoOfUpVotes() => NumberOfUpVotes ++;
          public int DecreaseNoOfUpVotes() => NumberOfUpVotes --;
    }
}
