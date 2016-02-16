using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Geocaching.Core;


namespace Geocaching.Data.Mapping
{
    class PhotoOfUserMap : EntityTypeConfiguration<PhotoOfUser>
    {
        public PhotoOfUserMap()
        {
            HasKey(m => m.id);
            Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ToTable("PhotoOfUser");

            HasRequired(m => m.user).WithMany(m => m.photos_of_user).HasForeignKey(m => m.id_user).WillCascadeOnDelete(false);
            HasRequired(m => m.photo).WithMany(m => m.photo_of_user).HasForeignKey(m => m.id_photo).WillCascadeOnDelete(false);
        }
    }
}
