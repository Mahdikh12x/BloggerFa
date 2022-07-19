using _0_Framework.Domain;
using BlogManagement.Application.Contracts.Post;

namespace BlogManagement.Domain.PostAgg;

public interface IPostRepository : IRepository<long, Post>
{
    EditPost? GetDetails(long id);
    Task<IEnumerable<PostViewModel>>? SearchAsync(PostSearchModel searchModel);
    
}