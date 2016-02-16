using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Geocaching.Core;

namespace Geocaching.Data.Mapping
{
    class PhotoOfCachesMap : EntityTypeConfiguration<PhotoOfCaches>
    {
        public PhotoOfCachesMap()
        {
            HasKey(m => m.id);
            Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ToTable("PhotoOfCaches");

            HasRequired(m => m.cache).WithMany(m => m.photo_of_caches).HasForeignKey(m => m.id_cache).WillCascadeOnDelete(false);
            HasRequired(m => m.photo).WithMany(m => m.photo_of_caches).HasForeignKey(m => m.id_photo).WillCascadeOnDelete(false);
        }
    }
}
