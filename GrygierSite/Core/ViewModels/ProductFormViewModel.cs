using GrygierSite.Core.Models;
using GrygierSite.Core.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace GrygierSite.Core.ViewModels
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ThumbnailPath { get; set; }

        [Required]
        [Display(Name = "Market URL")]
        public string MarketUrl { get; set; }

        [Required]
        [Display(Name = "Category")]
        public byte CategoryId { get; set; }

        public IEnumerable<int> TagIds { get; set; }

        [ImageFormat]
        public HttpPostedFileBase Thumbnail { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public string Title { get; set; }

        public string Action { get; set; }

        public string GetThumbnailPath()
        {
            return "Content/Images/Thumbnail-" + Id + Thumbnail.FileName.Substring(Thumbnail.FileName.LastIndexOf(".", StringComparison.Ordinal));
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