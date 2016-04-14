using System.Collections.Generic;

namespace Geocaching.Core
{
    public class Roles : BaseEntity
    {
        public string name { get; set; }

        public virtual List<UserInRoles> users { get; set; }

        public Roles()
        {
            users = new List<UserInRoles>();
        }
    }
}
