using System;
using System.ComponentModel.DataAnnotations;

namespace GrygierSite.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; }

        public DateTime DateOfIssue { get; set; }

        public DateTime LastUpdate { get; set; }

        [Required]
        [StringLength(1000)]
        public string MarketUrl { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}