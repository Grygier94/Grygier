using System.ComponentModel.DataAnnotations;

namespace GrygierSite.Models
{
    public class Category
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public byte? ParentCategoryId { get; set; }
    }
}