using GrygierSite.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace GrygierSite.ViewModels
{
    public class ProductFormViewModel
    {
        private HttpPostedFileBase _thumbnail;

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
        public byte Category { get; set; }

        [Display(Name = "Thumbnail")]
        public HttpPostedFileBase Thumbnail
        {
            get { return _thumbnail; }
            set
            {
                var extension = Path.GetExtension(value.FileName)?.ToLower();

                if (extension != null)
                {
                    if (extension == ".jpg" || extension == ".png" || extension == ".bmp"
                        || extension == ".jpeg" || extension == ".gif")
                    {
                        _thumbnail = value;
                    }
                }
            }
        }

        public string GetThumbnailPath()
        {
            return "Content/Images/" + Thumbnail.FileName;
        }

        public IEnumerable<Category> Categories { get; set; }
    }
}