using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Shared.Validation
{
    public class AllowedFileFormatAttribute : ValidationAttribute
    {
        private readonly string[] _allowedFormats;

        public AllowedFileFormatAttribute(params string[] allowedFormats)
        {
            _allowedFormats = allowedFormats;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!_allowedFormats.Contains(fileExtension))
                {
                    return new ValidationResult($"The file format '{fileExtension}' is not allowed. Allowed formats are: {string.Join(", ", _allowedFormats)}");
                }
            }

            return ValidationResult.Success;
        }
    }
}
