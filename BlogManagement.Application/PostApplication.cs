using _0_Framework.Application;
using BlogManagement.Application.Contracts.Post;
using BlogManagement.Domain.PostAgg;

namespace BlogManagement.Application;

public class PostApplication : IPostApplication
{
    private readonly IPostRepository _postRepository;
    private readonly OperationResult _operationResult;

    public PostApplication(IPostRepository repository)
    {
        _operationResult = new OperationResult();
        _postRepository = repository;
    }

    public OperationResult Create(CreatePost post)
    {
        try
        {
            if (_postRepository.Exists(c => c.Title == post.Title))
                return _operationResult.Failed("This Product Already Exists");

            var command = new Post(post.Title, post.Content, post.Link, 0, post.ShortDescription, DateTime.Now
                , post.Picture, post.PictureAlt, post.PictureTitle, post.CategoryId, post.StudyTime
                , post.Keywords, post.MetaDescription, post.CanonicalAddress);

            _postRepository.Create(command);
            _postRepository.SaveChanges();

            return _operationResult.Succeeded("The Operation is SuccessFull");
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

            currentPost?.Edit(post.MetaDescription, post.Keywords, post.Slug, post.CanonicalAddress, post.Title,
                post.Content, post.Link, 0, post.ShortDescription, DateTime.Now, post.Picture
                , post.PictureAlt, post.PictureTitle, post.CategoryId, post.StudyTime);
            _postRepository.SaveChanges();
            return _operationResult.Succeeded("The Operation Is SuccessFull");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return _operationResult.Failed("Invalid Operation");
        }
    }



    public EditPost? GetDetails(long id)
    {
        return _postRepository.GetDetails(id);
    }

    public async Task<int> IncreaseVoteAsync(long id)
    {
        var post = _postRepository.Get(id);
        post?.IncreaseNoOfUpVotes();
        await _postRepository.SaveChangesAsync();
        return post!.NumberOfUpVotes;
    }

    public async Task<int> DecreaseVoteToPostAsync(long id)
    {
        var post = _postRepository.Get(id);
        post?.DecreaseNoOfUpVotes();
        await _postRepository.SaveChangesAsync();
        return post!.NumberOfUpVotes;
    }

    public async Task<IEnumerable<PostViewModel>>? SearchAsync(PostSearchModel searchModel)
    {
        return await _postRepository.SearchAsync(searchModel)!;
    }

   
    public async Task ActiveAsync(long id)
    {
        var post = await _postRepository.GetByAsync(id)!;
        post?.Active();
        await _postRepository.SaveChangesAsync();
    }

    public async Task DeActiveAsync(long id)
    {
        var post = await _postRepository.GetByAsync(id)!;
        post?.DeActive();
        await _postRepository.SaveChangesAsync();
    }
}