using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Geocaching.Core;

namespace Geocaching.Data.Mapping
{
    class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            HasKey(m => m.id);
            Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.description).IsRequired();
            Property(m => m.date).IsRequired();
            ToTable("Comment");

            HasRequired(m => m.user).WithMany(m => m.comments).HasForeignKey(m => m.id_user).WillCascadeOnDelete(false);
            HasRequired(m => m.cache).WithMany(m => m.comments).HasForeignKey(m => m.id_cache).WillCascadeOnDelete(false);

        }
    }
}
