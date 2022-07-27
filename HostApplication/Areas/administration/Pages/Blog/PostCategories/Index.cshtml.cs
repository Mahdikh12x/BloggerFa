using BlogManagement.Application.Contracts.PostCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HostApplication.Areas.administration.Pages.Blog.PostCategories
{
    public class IndexModel : PageModel
    {
        private readonly IPostCategoryApplication _postCategoryApplication;
        public List<PostCategoryViewModel>? PostCategories { get; set; }
        
        public IndexModel(IPostCategoryApplication postCategoryApplication)
        {
            _postCategoryApplication = postCategoryApplication;
        }

        public Task<IActionResult> OnGet(PostCategorySearchModel searchModel)
        {
            PostCategories= _postCategoryApplication.SearchAsync(searchModel)?.Result;
            return Task.FromResult<IActionResult>(Page());
        }

        public PartialViewResult OnGetCreate()
        {
            return Partial("./Create");
        }

        public IActionResult OnPostCreate(CreatePostCategory command)
        {
            if (ModelState.IsValid)
            {
                return new JsonResult(_postCategoryApplication.Create(command));
            }
            return Page();
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var currentCategory =_postCategoryApplication.GetDetails(id)!;
            return  Partial("./Edit", currentCategory);
        }

        public IActionResult OnPostEdit(EditPostCategory command)
        {
            if (!ModelState.IsValid) return RedirectToPage("./Index");
            var result = _postCategoryApplication.Edit(command);
            return new JsonResult(result);

        }
    }
}
