using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;

namespace Geocaching.Interfases.Repository
{
    public interface IRolesRepository<T> : IRepository<T> where T : Roles
    {
        Roles GetRoleByName(string name);
    }
}
