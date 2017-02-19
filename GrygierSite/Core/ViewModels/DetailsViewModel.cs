using System;
using GrygierSite.Core.Models;

namespace GrygierSite.Core.ViewModels
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime LastUpdate { get; set; }
        public string MarketUrl { get; set; }
        public decimal Price { get; set; }
        public string ThumbnailPath { get; set; }
        public Category Category { get; set; }
        public bool AuthenticatedUser { get; set; }
    }
}