using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GrygierSite.Core.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

        public Tag()
        {
            Products = new Collection<Product>();
        }
    }
}