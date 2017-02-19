namespace GrygierSite.Core.Models
{
    public class Category
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte? ParentCategoryId { get; set; }
    }
}