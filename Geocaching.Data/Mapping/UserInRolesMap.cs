using System.Data.Entity.ModelConfiguration;
using Geocaching.Core;

namespace Geocaching.Data.Mapping
{
    class UserInRolesMap : EntityTypeConfiguration<UserInRoles>
    {
        public UserInRolesMap()
        {
            ToTable("UserInRoles");
            HasRequired(m => m.user).WithMany(m => m.users).HasForeignKey(m => m.id_user).WillCascadeOnDelete(false);
            HasRequired(m => m.roles).WithMany(m => m.users).HasForeignKey(m => m.id_roles).WillCascadeOnDelete(false);
        }
    }
}
