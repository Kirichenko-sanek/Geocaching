using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Geocaching.Core;

namespace Geocaching.Data.Mapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(m => m.id);
            Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.first_name).IsRequired().HasMaxLength(30);
            Property(m => m.last_name).IsRequired().HasMaxLength(30);
            Property(m => m.email).IsRequired();
            Property(m => m.password).IsRequired();
            Property(m => m.password_salt).IsRequired();
            Property(m => m.is_activated).IsRequired();
            ToTable("User");

        }
    }
}
