using GrygierSite.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrygierSite.ViewModels
{
    public class ProductFormViewModel
    {
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

        public IEnumerable<Category> Categories { get; set; }
    }
}