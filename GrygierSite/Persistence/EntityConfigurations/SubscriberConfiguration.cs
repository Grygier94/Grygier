using GrygierSite.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GrygierSite.Persistence.EntityConfigurations
{
    public class SubscriberConfiguration : EntityTypeConfiguration<Subscriber>
    {
        public SubscriberConfiguration()
        {
            Property(s => s.Name)
            .HasMaxLength(100)
            .IsRequired();

            Property(s => s.Email)
            .HasMaxLength(100)
            .IsRequired();
        }
    }
}