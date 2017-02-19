using GrygierSite.Core.Models;

namespace GrygierSite.Core.ViewModels
{
    public class DetailsViewModel
    {
        public Product Product { get; set; }
        public bool AuthenticatedUser { get; set; }
    }
}