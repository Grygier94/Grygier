using GrygierSite.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace GrygierSite.Core.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }

        [Display(Name = "Thumbnail")]
        [ImageFormat]
        public HttpPostedFileBase Thumbnail { get; set; }

        public string GetThumbnailPath()
        {
            return "Content/Images/" + Thumbnail.FileName;
        }

        public IEnumerable<Category> Categories { get; set; }

        public string Title { get; set; }

        public string Action { get; set; }
    }
}