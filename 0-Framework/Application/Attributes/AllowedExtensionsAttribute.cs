using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _0_Framework.Application.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute,IClientModelValidator
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = (IFormFile)value!;
            if (file == null) return ValidationResult.Success;
            
            var extensionFile = Path.GetExtension(file.FileName);
            //return !_extensions.Contains(extensionFile.ToLower())
            //    ?new ValidationResult(GetNotAllowedErrorMessage())
            //:ValidationResult.Success;
            return !_extensions.Contains(extensionFile.ToLower()) ? new ValidationResult(GetNotAllowedErrorMessage()) : ValidationResult.Success;
        }

        private  string GetNotAllowedErrorMessage() => $"The extension of file Is not allowed...";

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-AllowedExtensions", GetNotAllowedErrorMessage());
        }
    }

}
