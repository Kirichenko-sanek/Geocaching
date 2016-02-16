using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class PhotoOfUserRepository<T> : Repository<T>, IPhotoOfUserRepository<T> where T : PhotoOfUser
    {
        public PhotoOfUserRepository(DataContext context) : base(context)
        {
            
        }

        public PhotoOfUser GetPhotoUserByUserId(long idUser)
        {
            return _context.PhotoOfUser.FirstOrDefault(x => x.id_user == idUser);
        }
    }
}
