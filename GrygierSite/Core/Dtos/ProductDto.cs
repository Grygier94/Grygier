using System;

namespace GrygierSite.Core.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime LastUpdate { get; set; }
        public string MarketUrl { get; set; }
        public decimal Price { get; set; }
        public CategoryDto Category { get; set; }
        public string ThumbnailPath { get; set; }
    }
}