using GrygierSite.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GrygierSite.Persistence.EntityConfigurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.CategoryId)
                .IsRequired();

            Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(3000);

            Property(p => p.MarketUrl)
                .IsRequired()
                .HasMaxLength(1000);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(p => p.ThumbnailPath)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}