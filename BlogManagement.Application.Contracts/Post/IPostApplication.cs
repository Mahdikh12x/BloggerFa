using _0_Framework.Application;

namespace BlogManagement.Application.Contracts.Post
{
    public interface IPostApplication
    {
        OperationResult Create(CreatePost post);
        OperationResult Edit(EditPost post);
        Task<IEnumerable<PostViewModel>>? SearchAsync(PostSearchModel searchModel);
        EditPost? GetDetails(long id);
        Task<int> IncreaseVoteAsync(long id);
        Task<int> DecreaseVoteToPostAsync(long id);
        Task ActiveAsync(long id);
        Task DeActiveAsync(long id);
    }
}
