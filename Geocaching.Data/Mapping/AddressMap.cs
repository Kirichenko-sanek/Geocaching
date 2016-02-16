using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Geocaching.Core;

namespace Geocaching.Data.Mapping
{
    class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            HasKey(m => m.id);
            Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.longitude).IsRequired();
            Property(m => m.latitude).IsRequired();
            Property(m => m.country).HasMaxLength(50);
            Property(m => m.region).HasMaxLength(50);
            Property(m => m.city).HasMaxLength(50);
            ToTable("Address");

        }
    }
}
