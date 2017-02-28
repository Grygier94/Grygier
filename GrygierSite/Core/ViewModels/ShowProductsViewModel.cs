using GrygierSite.Core.Models;
using System.Collections.Generic;

namespace GrygierSite.Core.ViewModels
{
    public class ShowProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string Title { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public Categories Category { get; set; }
        public string TagName { get; set; }
        public string Action { get; set; }
    }
}