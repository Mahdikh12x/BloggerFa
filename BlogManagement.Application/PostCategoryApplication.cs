using _0_Framework.Application;
using BlogManagement.Application.Contracts.PostCategory;
using BlogManagement.Domain.PostCategoryAgg;

namespace BlogManagement.Application
{
    public class PostCategoryApplication : IPostCategoryApplication
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly OperationResult _operationResult;
        private readonly IFileUploader _uploader;
        public PostCategoryApplication(IPostCategoryRepository postCategoryRepository, IFileUploader uploader)
        {
            _postCategoryRepository = postCategoryRepository;
            _uploader = uploader;
            _operationResult = new OperationResult();
        }

        public OperationResult Create(CreatePostCategory command)
        {
            try
            {
                if (_postCategoryRepository.Exists(pc => pc.Name == command.Name))
                    return _operationResult.Failed("It is Duplicated ! Check It Again");
                var slug=command.Slug.Slugify();
                var picturePath =  _uploader.UploadFileAsync(command.Picture, $"//PostCategory{slug}").Result;
                var postCategory = new PostCategory(command.MetaDescription, command.Keywords, slug,
                    command.CanonicalAddress, command.Name, command.Description, picturePath, command.PictureAlt,
                    command.PictureTitle);
                _postCategoryRepository.Create(postCategory);

                _postCategoryRepository.SaveChanges();
             return   _operationResult.Succeeded("The Operation is SuccessFull");

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
                var slug = command.Slug.Slugify();
                var picturePath = _uploader.UploadFileAsync(command.Picture,$"/PostCategory/{slug}").Result;
                postCategory.Edit(command.MetaDescription,command.Keywords,command.Slug,command.CanonicalAddress,command.Name,command.Description,picturePath,command.PictureAlt
                    ,command.PictureTitle);
                _postCategoryRepository.SaveChanges();
                return _operationResult.Succeeded("The Operation is SuccessFull");
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

        public async Task<List<PostCategoryViewModel>>? SearchAsync(PostCategorySearchModel searchModel)
        {
            return await _postCategoryRepository.SearchAsync(searchModel)!;
        }

        public async Task<IEnumerable<PostCategorySelectList>>? GetPostCategoryNames()
        {
            return  await _postCategoryRepository.GetPostCategoryNames()!;
        }
    }
}
