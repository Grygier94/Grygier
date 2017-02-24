using GrygierSite.Core.Models;
using GrygierSite.Core.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace GrygierSite.Core.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }

        [ImageFormat]
        public HttpPostedFileBase Thumbnail { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public string Title { get; set; }

        public string Action { get; set; }

        public string GetThumbnailPath()
        {
            return "Content/Images/Thumbnail-" + Product.Id + Thumbnail.FileName.Substring(Thumbnail.FileName.LastIndexOf(".", StringComparison.Ordinal));
        }

        public string GetThumbnailFullPath()
        {
            return Path.Combine(HttpContext.Current.Server.MapPath("~/"), GetThumbnailPath());
        }

        public void SaveThumbnailOnServer()
        {
            Thumbnail.SaveAs(GetThumbnailFullPath());
        }
    }
}