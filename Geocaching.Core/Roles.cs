using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
