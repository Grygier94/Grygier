using GrygierSite.Core.Models;
using GrygierSite.Core.Validators;
using System;
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
            return "Content/Images/Thumbnail-" + Product.Id + Thumbnail.FileName.Substring(Thumbnail.FileName.LastIndexOf(".", StringComparison.Ordinal));
        }

        public IEnumerable<Category> Categories { get; set; }

        public string Title { get; set; }

        public string Action { get; set; }
    }
}