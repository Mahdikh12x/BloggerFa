using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Contracts.PostCategory;

public class PostCategoryViewModel
{
    public long Id { get; set; }
    public string? Name { get;  set; }
    public string? Picture { get;  set; }
    public string? CreationDate { get; set; }
    public string? Description { get;  set; }
}