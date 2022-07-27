using BlogManagement.Application.Contracts.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HostApplication.Areas.administration.Pages.Blog.Posts
{
    public class IndexModel : PageModel
    {
        private readonly IPostApplication _postApplication;
        public List<PostViewModel>? Posts { get; set; }
        public IndexModel(IPostApplication postCategoryApplication)
        {
            _postApplication = postCategoryApplication;
        }

        public Task<IActionResult> OnGet(PostSearchModel searchModel)
        {
            Posts = _postApplication.SearchAsync(searchModel)?.Result;
            return Task.FromResult<IActionResult>(Page());
        }

        public RedirectToPageResult OnGetGetDetails(long id)
        {
            var result = _postApplication.GetDetails(id);
            return RedirectToPage("./Edit",result);
        }

        public async Task<RedirectToPageResult> OnGetActive(long id)
        {
            await _postApplication.ActiveAsync(id);
            return RedirectToPage();
        }

        public async Task<RedirectToPageResult> OnGetDeActive(long id)
        {
            await _postApplication.DeActiveAsync(id);
            return RedirectToPage();
        }
    }
}
