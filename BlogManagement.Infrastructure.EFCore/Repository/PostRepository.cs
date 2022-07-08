using System.Globalization;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.Post;
using BlogManagement.Domain.PostAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class PostRepository:BaseRepository<long,Post>,IPostRepository
    {
        private readonly BlogContext _context;

        public PostRepository(BlogContext context):base(context)
        {
            _context = context;
        }


        public IEnumerable<PostViewModel>? Search(PostSearchModel searchModel)
        {
            var query = _context.Posts?.AsNoTracking().Select(post => new PostViewModel
            {
                Id = post.Id,
                NumberOfViews = post.NumberOfViews,
                NumberOfUpVotes = post.NumberOfUpVotes,
                Title = post.Title,
                UserId = post.UserId,
                PublishDate = post.PublishDate.ToString(CultureInfo.InvariantCulture),
                DateModified = post.DateModified.ToString(CultureInfo.InvariantCulture)
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query?.Where(x => x.Title == searchModel.Title);

            if (searchModel.CategoryId > 0)
                query = query?.Where(x => x.CategoryId == searchModel.CategoryId);

            return query?.AsNoTracking().ToList();
        }

        public Task<List<PostViewModel>>? SearchAsync(PostSearchModel searchModel)
        {
            var query = _context.Posts?.AsNoTracking().Select(post => new PostViewModel
            {
                Id = post.Id,
                NumberOfViews = post.NumberOfViews,
                NumberOfUpVotes = post.NumberOfUpVotes,
                Title = post.Title,
                UserId = post.UserId,
                PublishDate = post.PublishDate.ToString(CultureInfo.InvariantCulture),
                DateModified = post.DateModified.ToString(CultureInfo.InvariantCulture)
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query?.Where(x => x.Title == searchModel.Title);

            if (searchModel.CategoryId > 0)
                query = query?.Where(x => x.CategoryId == searchModel.CategoryId);

            return   query?.AsNoTracking().ToListAsync();
        }

        public EditPost? GetDetails(long id)
        {
            return _context.Posts?.AsNoTracking().Select(post => new EditPost
            {
                Id = post.Id,
                Content = post.Content,
                Link = post.Link,
                Picture = post.Picture,
                PictureAlt = post.PictureAlt,
                PictureTitle = post.PictureTitle,
                ShortDescription = post.ShortDescription,
                PublishDate = post.PublishDate.ToString(CultureInfo.InvariantCulture),
                Title = post.Title,
                Keywords = post.Keywords,
                CanonicalAddress = post.CanonicalAddress,
                MetaDescription = post.MetaDescription,
                Slug = post.ShortDescription
            }).FirstOrDefault(i => i.Id == id);
        }
    }
}
