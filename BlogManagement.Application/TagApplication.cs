using System.Collections;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.Tag;
using BlogManagement.Domain.PostAgg;
using BlogManagement.Domain.TagAgg;

namespace BlogManagement.Application
{
    public class TagApplication : ITagApplication
    {
        private readonly ITagRepository _tagRepository;
        private readonly OperationResult _operationResult;
        public TagApplication(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
            _operationResult = new OperationResult();
        }

        public EditTag? GetDetails(long id)
        {
            return _tagRepository.GetDetails(id);
        }

        public OperationResult Edit(EditTag command)
        {
            try
            {
                var tag = _tagRepository.Get(command.Id);
                if (_tagRepository.Exists(t => t.Name == command.Name && t.Id != command.Id))
                    return _operationResult.Failed("Duplicated");
                if(tag== null)
                    return _operationResult.Failed("Duplicated");
                ICollection<Post> posts = new List<Post>();
                tag.Edit(command.Name);
                _tagRepository.SaveChanges();
                return _operationResult.Succeeded("SuccessFull");
            }
            catch (Exception exception)
            {
                    Console.WriteLine(exception);
                    return _operationResult.Failed("The Operation Is Failed");
            }
        }

        public OperationResult Create(CreateTag command)
        {
            try
            {
                if (_tagRepository.Exists(t => t.Name == command.Name ))
                    return _operationResult.Failed("Duplicated");
                ICollection<Post> posts = new List<Post>();
                var tag = new Tag(command.Name);
                _tagRepository.Create(tag);
                _tagRepository.SaveChanges();
                return _operationResult.Succeeded("SuccessFull");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return _operationResult.Failed("The Operation Is Failed");
            }
        }

        public List<TagViewModel>? Search(TagSearchModel searchModel)
        {
            return _tagRepository.Search(searchModel);
        }
    }
}
