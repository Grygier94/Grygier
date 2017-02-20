using System;
using System.ComponentModel.DataAnnotations;

namespace GrygierSite.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime LastUpdate { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public string ThumbnailPath { get; set; }

        [Display(Name = "Market URL")]
        public string MarketUrl { get; set; }

        [Display(Name = "Category")]
        public byte CategoryId { get; set; }
    }
}