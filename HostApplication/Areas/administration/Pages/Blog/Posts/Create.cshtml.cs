using BlogManagement.Application.Contracts.Post;
using BlogManagement.Application.Contracts.PostCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HostApplication.Areas.administration.Pages.Blog.Posts
{
    public class CreateModel : PageModel
    {
        private readonly IPostApplication _postApplication;
        private readonly IPostCategoryApplication _postCategoryApplication;
        public SelectList ProductCategories { get; set; }
        public CreatePost Post { get; set; }
        public CreateModel(IPostApplication postApplication, IPostCategoryApplication postCategoryApplication)
        {
            _postApplication = postApplication;
            _postCategoryApplication = postCategoryApplication;
        }

        public void OnGet()
        {
            ProductCategories = new SelectList( _postCategoryApplication.GetPostCategoryNames()!.Result, "Id", "Name");
        }

        public IActionResult OnPost(CreatePost post)
        {
            
            var result = _postApplication.Create(post);
            return new JsonResult(result);

        }
    }
}
