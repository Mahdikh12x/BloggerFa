using _0_Framework.Application;

namespace BlogManagement.Application.Contracts.Post
{
    public interface IPostApplication
    {
        OperationResult Create(CreatePost post);
        OperationResult Edit(EditPost post);
        IEnumerable<PostViewModel> Search(PostSearchModel searchModel);
        EditPost? GetDetails(long id);
        int IncreaseVote(long id);
        int DecreaseVoteToPost(long id);
        void Active(long id);
        void DeActive(long id);
    }
}
