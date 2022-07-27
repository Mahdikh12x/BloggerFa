using System.ComponentModel.DataAnnotations;
using _0_Framework.Application.Messages;

namespace _0_Framework.Application
{
    public class SeoTags
    {
        [Required(ErrorMessage=ValidationMessage.RequiredMessage)]
        public string MetaDescription { get; set; } = null!;
        [Required(ErrorMessage=ValidationMessage.RequiredMessage)]
        public string Slug { get; set; } = null!;
        [Required(ErrorMessage=ValidationMessage.RequiredMessage)]
        public string Keywords { get; set; } = null!;
        public string? CanonicalAddress { get;  set; } 

    }
}
