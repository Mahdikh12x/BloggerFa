using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _0_Framework.Application.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = (IFormFile)value!;
            if (file==null) return ValidationResult.Success;

                //return _maxFileSize > file.Length ? new ValidationResult(GetErrorMessage()) : ValidationResult.Success;
                return _maxFileSize < file.Length ? new ValidationResult(GetErrorMessage()) : ValidationResult.Success;
        }


        private string GetErrorMessage() => $" Maximum allowed file size is {_maxFileSize} bytes.";

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-maxsize", GetErrorMessage());
        }
    }
}
