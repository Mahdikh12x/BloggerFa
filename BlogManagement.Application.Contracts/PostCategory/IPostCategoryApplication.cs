using _0_Framework.Application;

namespace BlogManagement.Application.Contracts.PostCategory
{
    public interface IPostCategoryApplication
    {
        OperationResult Create(CreatePostCategory command);
        OperationResult Edit(EditPostCategory command);
        EditPostCategory? GetDetails(long id);
        List<PostCategoryViewModel>? Search(PostCategorySearchModel searchModel);
    }
}
