using GrygierSite.Core.Models;
using GrygierSite.Core.Validators;
using System.Collections.Generic;
using System.Web;

namespace GrygierSite.Core.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }

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