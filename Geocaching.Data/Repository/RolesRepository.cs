using System.Linq;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class RolesRepository<T> : Repository<T>, IRolesRepository<T> where T: Roles
    {
        public RolesRepository(DataContext context) : base(context)
        {
            
        }

        public Roles GetRoleByName(string name)
        {
            return _context.Roles.FirstOrDefault(x => x.name == name);
        }
    }
}
