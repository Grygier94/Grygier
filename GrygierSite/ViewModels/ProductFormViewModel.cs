using GrygierSite.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace GrygierSite.ViewModels
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Market url")]
        public string MarketUrl { get; set; }

        [Required]
        public byte CategoryId { get; set; }

        [Display(Name = "Thumbnail")]
        [ImageFormat]
        public HttpPostedFileBase Thumbnail { get; set; }

        public decimal Price { get; set; }

        public string GetThumbnailPath()
        {
            return "Content/Images/" + Thumbnail.FileName;
        }

        public IEnumerable<Category> Categories { get; set; }

        public string Title { get; set; }

        public string Action { get; set; }

        public ProductFormViewModel() { }

        public ProductFormViewModel(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            CategoryId = product.CategoryId;
            Price = product.Price;
            MarketUrl = product.MarketUrl;
        }
    }
}