using GrygierSite.Core.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace GrygierSite.Core.Validators
{
    public class ImageFormat : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var productFormViewModel = (ProductFormViewModel)validationContext.ObjectInstance;

            if (productFormViewModel.Thumbnail == null && String.IsNullOrWhiteSpace(productFormViewModel.ThumbnailPath))
                return new ValidationResult("Thumbnail is required.");

            if (productFormViewModel.Thumbnail == null)
                return ValidationResult.Success;

            var extension = Path.GetExtension(productFormViewModel.Thumbnail.FileName);

            if (string.IsNullOrWhiteSpace(extension))
                return new ValidationResult("Wrong path. Choose proper file");

            extension = extension.ToLower();

            return (extension == ".jpg" || extension == ".png" || extension == ".bmp" ||
                    extension == ".jpeg" || extension == ".gif")
                ? ValidationResult.Success
                : new ValidationResult("Wrong image format! Available formats: .bmp, .png, .jpg. .jpeg, .gif");

        }
    }
}