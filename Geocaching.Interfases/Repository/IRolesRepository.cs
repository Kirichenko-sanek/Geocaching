using Geocaching.Core;

namespace Geocaching.Interfases.Repository
{
    public interface IRolesRepository<T> : IRepository<T> where T : Roles
    {
        Roles GetRoleByName(string name);
    }
}
