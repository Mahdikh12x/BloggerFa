using _0_Framework.Domain;
using BlogManagement.Application.Contracts.PostCategory;

namespace BlogManagement.Domain.PostCategoryAgg
{
    public interface IPostCategoryRepository:IRepository<long,PostCategory>
    {
        EditPostCategory? GetDetails(long id);
        List<PostCategoryViewModel>? Search(PostCategorySearchModel searchModel);
        Task<List<PostCategoryViewModel>?> SearchAsync(PostCategorySearchModel searchModel);
    }
}
