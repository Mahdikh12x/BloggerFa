using _0_Framework.Application;
using BlogManagement.Application.Contracts.Post;
using BlogManagement.Domain.PostAgg;

namespace BlogManagement.Application;

internal class PostApplication:IPostApplication
{
    private readonly IPostRepository _postRepository;
    private readonly OperationResult _operationResult;
    public PostApplication(IPostRepository repository)
    {
        _operationResult = new OperationResult("Posts");
        _postRepository = repository;
    }

    public OperationResult Create(CreatePost post)
    {
        try
        {
            if (_postRepository.Exists(c => c.Title == post.Title))
                return _operationResult.Failed("This Product Already Exists");

            var command = new Post(post.MetaDescription, post.Keywords, post.Slug, post.CanonicalAddress, post.Title,
                post.Content, post.Link, 0, post.ShortDescription, DateTime.Now, post.Picture,
                post.PictureAlt, post.PictureTitle, post.CategoryId,post.StudyTime);

            _postRepository.Create(command);
            _postRepository.SaveChanges();

            return _operationResult.But("Posts").Succeeded("The Operation is SuccessFull");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            _operationResult.Failed("Operation Do not Work ,Call The Administration!!!");
                throw;
        }
    }

    public OperationResult Edit(EditPost post)
    {
        try
        {
            var currentPost = _postRepository.Get(post.Id);
            if (_postRepository.Exists(c => c.Id != post.Id && c.Title == post.Title))
                return _operationResult.Failed("Duplicated");

            currentPost?.Edit(post.MetaDescription,post.Keywords,post.Slug,post.CanonicalAddress,post.Title,post.Content,post.Link,0,post.ShortDescription,DateTime.Now, post.Picture
                ,post.PictureAlt,post.PictureTitle,post.CategoryId,post.StudyTime);
            _postRepository.SaveChanges();
            return _operationResult.But("Posts").Succeeded("The Operation Is SuccessFull");

        }
        catch (Exception exception)
        {
                Console.WriteLine(exception);
           return _operationResult.Failed("Invalid Operation");
                
        }
    }

    public IEnumerable<PostViewModel> Search(PostSearchModel searchModel)
    {
        return _postRepository.Search(searchModel);
    }


    public EditPost? GetDetails(long id)
    {
        return _postRepository.GetDetails(id);
    }

    public int IncreaseVote(long id)
    {
        var post= _postRepository.Get(id);
        post?.IncreaseNoOfUpVotes();
        _postRepository.SaveChanges();
        return post!.NumberOfUpVotes;
    }

    public int DecreaseVoteToPost(long id)
    {
        var post = _postRepository.Get(id);
        post?.DecreaseNoOfUpVotes();
        _postRepository.SaveChanges();
        return post!.NumberOfUpVotes;

    }

    public void Active(long id)
    {
        var post = _postRepository.Get(id);
        post?.Active();
        _postRepository.SaveChanges();
    }

    public void DeActive(long id)
    {
        var post = _postRepository.Get(id);
        post?.DeActive();
        _postRepository.SaveChanges();
    }
}