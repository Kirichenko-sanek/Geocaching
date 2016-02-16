using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Geocaching.Core;

namespace Geocaching.Data.Mapping
{
    class PhotoOfListOfVisitedCachesMap : EntityTypeConfiguration<PhotoOfListOfVisitedCaches>
    {
        public PhotoOfListOfVisitedCachesMap()
        {
            HasKey(m => m.id);
            Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ToTable("PhotoOfListOfVisitedCaches");

            HasRequired(m => m.list).WithMany(m => m.photo_of_list_of_visited_caches).HasForeignKey(m => m.id_list).WillCascadeOnDelete(false);
            HasRequired(m => m.photo).WithMany(m => m.photo_of_list_of_visited_caches).HasForeignKey(m => m.id_photo).WillCascadeOnDelete(false);
        }
    }
}
