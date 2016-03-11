using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Geocaching.Core;

namespace Geocaching.Data.Mapping
{
    class ListOfVisitedCachesMap : EntityTypeConfiguration<ListOfVisitedCaches>
    {
        public ListOfVisitedCachesMap()
        {
            HasKey(m => m.id);
            Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.date).IsRequired();
            ToTable("ListOfVisitedCaches");

            HasRequired(m => m.cache).WithMany(m => m.list_of_visited_caches).HasForeignKey(m => m.id_cache).WillCascadeOnDelete(false);
            HasRequired(m => m.user).WithMany(m => m.list_of_visited_cache).HasForeignKey(m => m.id_user).WillCascadeOnDelete(false);
        }
    }
}
