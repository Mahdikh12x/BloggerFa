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

        public EditPost? GetDetails(long id)
        {
            return _context.Posts?.AsNoTracking().Select(post => new EditPost
            {
                Id = post.Id,
                Content = post.Content,
                Link = post.Link!,
                Picture = post.Picture!,
                PictureAlt = post.PictureAlt!,
                PictureTitle = post.PictureTitle!,
                ShortDescription = post.ShortDescription,
                PublishDate = post.PublishDate.ToString(CultureInfo.InvariantCulture),
                Title = post.Title,
                Keywords = post.Keywords,
                CanonicalAddress = post.CanonicalAddress,
                MetaDescription = post.MetaDescription,
                Slug = post.ShortDescription
            }).FirstOrDefault(i => i.Id == id);
        }

        public async Task<IEnumerable<PostViewModel>>? SearchAsync(PostSearchModel searchModel)
        {
            var query =  _context.Posts?.Select(p => new PostViewModel
            {
                Id = p.Id,
                Title = p.Title,
                NumberOfViews = p.NumberOfViews,
                NumberOfUpVotes = p.NumberOfUpVotes,
                CategoryId = p.CategoryId,
                PublishDate = p.PublishDate.ToString(CultureInfo.CurrentCulture),
                DateModified = p.ModifiedDate.ToShortDateString(),
                AuthorId = p.UserId,
                AuthorName = "Admin"
            }).AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query?.Where(s => s.Title.Contains(searchModel.Title));

            
            if(!string.IsNullOrWhiteSpace(searchModel.AuthorName))
                query = query?.Where(s => s.Title.Contains(searchModel.AuthorName));

            if (searchModel.CategoryId > 0)
                query = query?.Where(s => s.CategoryId == searchModel.CategoryId);
            
            
            return await query?.AsNoTracking().OrderByDescending(s => s.Id).ToListAsync()!;
        }
    }
}
