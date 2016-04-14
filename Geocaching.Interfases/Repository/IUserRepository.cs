using Geocaching.Core;

namespace Geocaching.Interfases.Repository
{
    public interface IUserRepository<T> : IRepository<T> where T : User
    {
        User GetUserByEmail(string email);
    }
}
