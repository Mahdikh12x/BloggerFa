using BlogManagement.Application.Contracts.Post;
using BlogManagement.Application.Contracts.PostCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HostApplication.Areas.administration.Pages.Blog.Posts
{
    public class EditModel : PageModel
    {
        public EditPost Post { get; set; } = null!;
        public SelectList? PostCategories { get; set; }
        private readonly IPostApplication _postApplication;
        private readonly IPostCategoryApplication _postCategoryApplication;
        public EditModel(IPostApplication postApplication, IPostCategoryApplication postCategoryApplication)
        {
            _postApplication = postApplication;
            _postCategoryApplication = postCategoryApplication;
        }

        public void OnGet(long id)
        {
            Post = _postApplication.GetDetails(id)!;
            PostCategories = new SelectList(_postCategoryApplication.GetPostCategoryNames()!.Result, "Id", "Name");
        }

        public IActionResult OnPost(EditPost post)
        {
            var result = _postApplication.Edit(post);
            return result.IsSuccess ? RedirectToPage("/Index") : RedirectToPage("./Edit",new {Id=post.Id});
        }
    }
}
