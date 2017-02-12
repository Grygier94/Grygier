using GrygierSite.Models;
using System.Collections.Generic;

namespace GrygierSite.ViewModels
{
    public class ProductFormViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string MarketUrl { get; set; }
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}