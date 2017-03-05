using System.Collections.Generic;

namespace GrygierSite.Core.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

        public Tag()
        {
            Products = new HashSet<Product>();
        }
    }
}