using _0_Framework.Domain;
using BlogManagement.Application.Contracts.Post;

namespace BlogManagement.Domain.PostAgg;

public interface IPostRepository : IRepository<long, Post>
{
    EditPost? GetDetails(long id);
    IEnumerable<PostViewModel>? Search(PostSearchModel searchModel);
    Task<List<PostViewModel>>? SearchAsync(PostSearchModel searchModel);
}