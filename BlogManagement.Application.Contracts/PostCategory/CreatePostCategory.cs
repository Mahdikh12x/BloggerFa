using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using _0_Framework.Application.Attributes;
using _0_Framework.Application.Messages;
using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contracts.PostCategory;

public class CreatePostCategory:SeoTags
{
    [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
    public string Description { get; set; } = null!;
    [MaxFileSize(5*1024*1024,ErrorMessage = ValidationMessage.MaxFileSizeMessage)]
    [AllowedExtensions(new[] { ".jpg", ".png",".jpeg" })]
    public IFormFile? Picture { get; set; }
    public string? PictureAlt { get; set; }
    public string? PictureTitle { get; set; }
}

