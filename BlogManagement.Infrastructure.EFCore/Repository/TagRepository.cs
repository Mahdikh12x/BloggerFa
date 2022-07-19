using System.Globalization;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.Post;
using BlogManagement.Application.Contracts.Tag;
using BlogManagement.Domain.TagAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class TagRepository:BaseRepository<long,Tag>,ITagRepository
    {
        private readonly BlogContext _blogContext;

        public TagRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public EditTag? GetDetails(long id)
        {
            return _blogContext.Tags?.AsNoTracking().Include(c=>c.Posts).Select(t => new EditTag
            {
                Id = t.Id,
                Name = t.Name,
                Posts = new List<PostViewModel>()
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<TagViewModel>? Search(TagSearchModel searchModel)
        {
            var query = _blogContext.Tags?.Select(t => new TagViewModel
            {
                Id = t.Id,
                Name = t.Name,
                CreationDate =t.CreationDate.ToString(CultureInfo.InvariantCulture) 
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query?.Where(t => t.Name.Contains(searchModel.Name));

            return query?.AsNoTracking().OrderByDescending(t => t.Id).ToList();


        }
    }
}
