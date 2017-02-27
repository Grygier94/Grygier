using GrygierSite.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GrygierSite.Persistence.EntityConfigurations
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}