using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Geocaching.Core;

namespace Geocaching.Data.Mapping
{
    class PhotoMap : EntityTypeConfiguration<Photo>
    {
        public PhotoMap()
        { 
            HasKey(m => m.id);
            Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.name).IsRequired();
            Property(m => m.date);
            ToTable("Photo");
        }
    }
}
