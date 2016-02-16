using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class UserInRolesRepository<T> : Repository<T>, IUserInRolesRepository<T> where T : UserInRoles
    {
        public UserInRolesRepository(DataContext context) : base(context)
        {
            
        } 
    }
}
