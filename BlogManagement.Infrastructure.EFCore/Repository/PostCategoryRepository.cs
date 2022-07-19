using System.Globalization;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.PostCategory;
using BlogManagement.Domain.PostCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class PostCategoryRepository:BaseRepository<long,PostCategory>,IPostCategoryRepository
    {
        private readonly BlogContext _blogContext;

        public PostCategoryRepository(BlogContext context):base(context)
        {
            _blogContext = context;
        }
        public EditPostCategory? GetDetails(long id)
        {
            return _blogContext.PostCategories?.AsNoTracking().Select(pc => new EditPostCategory
            {
                Id = pc.Id,
                Name = pc.Name,
                PictureAlt = pc.PictureAlt,
                CanonicalAddress = pc.CanonicalAddress!,
                Description = pc.Description,
                Keywords = pc.Keywords,
                 PictureTitle = pc.PictureTitle,
                 Picture = pc.Picture,
                 MetaDescription = pc.MetaDescription,
                 Slug = pc.Slug,
            }).FirstOrDefault(x=>x.Id==id);
        }


        public async Task<List<PostCategoryViewModel>>? SearchAsync(PostCategorySearchModel searchModel)
        {
            var query = _blogContext.PostCategories?.AsNoTracking().Select(pc => new PostCategoryViewModel
            {
                Id = pc.Id,
                Picture = pc.Picture,
                Name = pc.Name,
                CreationDate = pc.CreationDate.ToString(CultureInfo.InvariantCulture),
                Description = pc.Description
            }).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query?.Where(x => x.Name!.Contains(searchModel.Name));
            var result= query?.OrderByDescending(c=>c.Id).AsNoTracking().ToListAsync();
            
            return await result!;
        }
    }
}
