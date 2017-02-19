using System.ComponentModel.DataAnnotations;
using System.IO;
using GrygierSite.Core.ViewModels;

namespace GrygierSite.Core.Validators
{
    public class ImageFormat : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (ProductFormViewModel)validationContext.ObjectInstance;

            if (product.Thumbnail == null)
                return new ValidationResult("Thumbnail is required.");

            var extension = Path.GetExtension(product.Thumbnail.FileName);

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