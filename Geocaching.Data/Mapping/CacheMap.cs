using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Geocaching.Core;

namespace Geocaching.Data.Mapping
{
    class CacheMap : EntityTypeConfiguration<Cache>
    {
        public CacheMap()
        {
            HasKey(m => m.id);
            Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.name).IsRequired().HasMaxLength(50);
            Property(m => m.description).IsRequired();
            Property(m => m.date_of_apperance).IsRequired();
            Property(m => m.date_of_last_visit).IsRequired();
            ToTable("Cache");

            HasRequired(m => m.user).WithMany(m => m.caches).HasForeignKey(m => m.id_user).WillCascadeOnDelete(false);
            HasRequired(m => m.address).WithMany(m => m.caches).HasForeignKey(m => m.id_address).WillCascadeOnDelete(false);
        }
    }
}
