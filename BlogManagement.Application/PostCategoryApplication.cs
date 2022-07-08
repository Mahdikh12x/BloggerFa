using _0_Framework.Application;
using BlogManagement.Application.Contracts.PostCategory;
using BlogManagement.Domain.PostCategoryAgg;

namespace BlogManagement.Application
{
    public class PostCategoryApplication : IPostCategoryApplication
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly OperationResult _operationResult;
        public PostCategoryApplication(IPostCategoryRepository postCategoryRepository)
        {
            _postCategoryRepository = postCategoryRepository;
            _operationResult = new OperationResult("PostCategories");
        }

        public OperationResult Create(CreatePostCategory command)
        {
            try
            {
                if (_postCategoryRepository.Exists(pc => pc.Name == command.Name))
                    return _operationResult.Failed("It is Duplicated ! Check It Again");

                var postCategory = new PostCategory(command.MetaDescription, command.Keywords, command.Slug,
                    command.CanonicalAddress, command.Name, command.Description, command.Picture, command.PictureAlt,
                    command.PictureTitle);
                _postCategoryRepository.Create(postCategory);

                _postCategoryRepository.SaveChanges();
                _operationResult.But("Posts").Succeeded("The Operation is SuccessFull");

                throw new NotImplementedException();
            }
            catch (Exception exception)
            {

                        Console.WriteLine(exception);
                        return _operationResult.Failed("The Operation is Failed! Call The Administration");
            }
        }

        public OperationResult Edit(EditPostCategory command)
        {
            try
            {
                var postCategory = _postCategoryRepository.Get(command.Id);
                if (_postCategoryRepository.Exists(pc => pc.Name == command.Name && pc.Id != command.Id))
                    return _operationResult.Failed("There is a Duplication ! Check it Again");
                if (postCategory == null)
                    return _operationResult.Failed("There is no Object To Find ! Try Again");
                postCategory.Edit(command.MetaDescription,command.Keywords,command.Slug,command.CanonicalAddress,command.Name,command.Description,command.Picture,command.PictureAlt
                    ,command.PictureTitle);
                _postCategoryRepository.SaveChanges();
                return _operationResult.But("PostCategories").Succeeded("The Operation is SuccessFull");
            }
            catch (Exception exception)
            {
                    Console.WriteLine(exception);
                  return  _operationResult.Failed("The Operation Is Failed ! Call The Manager");
            }
        }

        public EditPostCategory? GetDetails(long id)
        {
           return _postCategoryRepository.GetDetails(id);
        }

        public  List<PostCategoryViewModel>? Search(PostCategorySearchModel searchModel)
        {
            return _postCategoryRepository.Search(searchModel);
        }
    }
}
