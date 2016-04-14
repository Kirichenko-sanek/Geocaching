using System.Linq;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class UserRepository<T> : Repository<T>,IUserRepository<T> where T : User
    {
        public UserRepository(DataContext context) : base(context)
        {
            
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.email == email);
        }
    }
}
